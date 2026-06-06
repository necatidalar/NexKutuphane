using Microsoft.EntityFrameworkCore;
using NexKutuphane.Application.Abstractions;
using NexKutuphane.Contracts.Common;
using NexKutuphane.Contracts.Locations;
using NexKutuphane.Domain.Entities;
using NexKutuphane.Infrastructure.Persistence.Context;

namespace NexKutuphane.Infrastructure.Services;

public class LocationService : ILocationService
{
    private readonly AppDbContext _context;

    public LocationService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ApiResponse<List<LocationSectionResponse>>> GetSectionsAsync()
    {
        var sections = await _context.YerlesimBolumleri
            .AsNoTracking()
            .OrderBy(x => x.BolumAdi)
            .Select(x => new LocationSectionResponse
            {
                Id = x.Id,
                BolumAdi = x.BolumAdi,
                BolumKodu = x.BolumKodu,
                Aciklama = x.Aciklama,
                AktifMi = x.AktifMi
            })
            .ToListAsync();

        return ApiResponse<List<LocationSectionResponse>>.Success(
            sections,
            "Yerleşim bölümleri başarıyla getirildi.");
    }

    public async Task<ApiResponse<List<LocationCabinetResponse>>> GetCabinetsAsync(int? sectionId)
    {
        var query = _context.Dolaplar
            .AsNoTracking()
            .Include(x => x.YerlesimBolumu)
            .AsQueryable();

        if (sectionId.HasValue)
        {
            query = query.Where(x => x.YerlesimBolumuId == sectionId.Value);
        }

        var cabinets = await query
            .OrderBy(x => x.YerlesimBolumu.BolumAdi)
            .ThenBy(x => x.DolapAdi)
            .Select(x => new LocationCabinetResponse
            {
                Id = x.Id,
                DolapAdi = x.DolapAdi,
                DolapKodu = x.DolapKodu,
                YerlesimBolumuId = x.YerlesimBolumuId,
                YerlesimBolumuAdi = x.YerlesimBolumu.BolumAdi,
                Aciklama = x.Aciklama,
                AktifMi = x.AktifMi
            })
            .ToListAsync();

        return ApiResponse<List<LocationCabinetResponse>>.Success(
            cabinets,
            "Dolap listesi başarıyla getirildi.");
    }

    public async Task<ApiResponse<List<LocationShelfResponse>>> GetShelvesAsync(int? cabinetId)
    {
        var query = _context.Raflar
            .AsNoTracking()
            .Include(x => x.Dolap)
                .ThenInclude(x => x.YerlesimBolumu)
            .AsQueryable();

        if (cabinetId.HasValue)
        {
            query = query.Where(x => x.DolapId == cabinetId.Value);
        }

        var shelves = await query
            .OrderBy(x => x.Dolap.YerlesimBolumu.BolumAdi)
            .ThenBy(x => x.Dolap.DolapAdi)
            .ThenBy(x => x.SiraNo)
            .Select(x => new LocationShelfResponse
            {
                Id = x.Id,
                RafAdi = x.RafAdi,
                RafKodu = x.RafKodu,
                SiraNo = x.SiraNo,
                DolapId = x.DolapId,
                DolapAdi = x.Dolap.DolapAdi,
                YerlesimBolumuId = x.Dolap.YerlesimBolumuId,
                YerlesimBolumuAdi = x.Dolap.YerlesimBolumu.BolumAdi,
                TamKonum = x.Dolap.YerlesimBolumu.BolumAdi + " / " + x.Dolap.DolapAdi + " / " + x.RafAdi,
                AktifMi = x.AktifMi
            })
            .ToListAsync();

        return ApiResponse<List<LocationShelfResponse>>.Success(
            shelves,
            "Raf listesi başarıyla getirildi.");
    }

    public async Task<ApiResponse<List<BookLocationResponse>>> GetBookLocationsAsync()
    {
        var locations = await GetBookLocationQuery()
            .AsNoTracking()
            .Where(x => x.AktifMi)
            .OrderBy(x => x.Kitap.KitapAdi)
            .ToListAsync();

        return ApiResponse<List<BookLocationResponse>>.Success(
            locations.Select(MapToBookLocationResponse).ToList(),
            "Kitap konumları başarıyla getirildi.");
    }

    public async Task<ApiResponse<List<BookLocationResponse>>> GetBookLocationsByBookIdAsync(int bookId)
    {
        var locations = await GetBookLocationQuery()
            .AsNoTracking()
            .Where(x => x.KitapId == bookId && x.AktifMi)
            .OrderBy(x => x.Raf.Dolap.YerlesimBolumu.BolumAdi)
            .ThenBy(x => x.Raf.Dolap.DolapAdi)
            .ThenBy(x => x.Raf.SiraNo)
            .ToListAsync();

        return ApiResponse<List<BookLocationResponse>>.Success(
            locations.Select(MapToBookLocationResponse).ToList(),
            "Kitaba ait konumlar başarıyla getirildi.");
    }

    public async Task<ApiResponse<BookLocationResponse>> CreateBookLocationAsync(BookLocationCreateRequest request)
    {
        var errors = await ValidateCreateAsync(request);

        if (errors.Any())
        {
            return ApiResponse<BookLocationResponse>.Fail(errors);
        }

        var inactiveLocation = await _context.KitapKonumlari
            .FirstOrDefaultAsync(x =>
                x.KitapId == request.KitapId &&
                x.RafId == request.RafId &&
                !x.AktifMi);

        if (inactiveLocation is not null)
        {
            inactiveLocation.AktifMi = true;
            inactiveLocation.KonumKodu = NormalizeNullable(request.KonumKodu);
            inactiveLocation.Aciklama = NormalizeNullable(request.Aciklama);
            inactiveLocation.GuncellemeTarihi = DateTime.Now;

            await _context.SaveChangesAsync();

            var reactivated = await GetBookLocationQuery()
                .AsNoTracking()
                .FirstAsync(x => x.Id == inactiveLocation.Id);

            return ApiResponse<BookLocationResponse>.Success(
                MapToBookLocationResponse(reactivated),
                "Pasif konum kaydı tekrar aktif edildi.");
        }

        var location = new KitapKonum
        {
            KitapId = request.KitapId,
            RafId = request.RafId,
            KonumKodu = NormalizeNullable(request.KonumKodu),
            Aciklama = NormalizeNullable(request.Aciklama),
            AktifMi = true,
            OlusturmaTarihi = DateTime.Now
        };

        await _context.KitapKonumlari.AddAsync(location);
        await _context.SaveChangesAsync();

        var createdLocation = await GetBookLocationQuery()
            .AsNoTracking()
            .FirstAsync(x => x.Id == location.Id);

        return ApiResponse<BookLocationResponse>.Success(
            MapToBookLocationResponse(createdLocation),
            "Kitap konumu başarıyla eklendi.");
    }

    public async Task<ApiResponse<BookLocationResponse>> UpdateBookLocationAsync(int id, BookLocationUpdateRequest request)
    {
        var location = await _context.KitapKonumlari.FirstOrDefaultAsync(x => x.Id == id);

        if (location is null)
        {
            return ApiResponse<BookLocationResponse>.Fail("Güncellenecek kitap konumu bulunamadı.");
        }

        var errors = await ValidateUpdateAsync(id, location.KitapId, request);

        if (errors.Any())
        {
            return ApiResponse<BookLocationResponse>.Fail(errors);
        }

        location.RafId = request.RafId;
        location.KonumKodu = NormalizeNullable(request.KonumKodu);
        location.Aciklama = NormalizeNullable(request.Aciklama);
        location.AktifMi = request.AktifMi;
        location.GuncellemeTarihi = DateTime.Now;

        await _context.SaveChangesAsync();

        var updatedLocation = await GetBookLocationQuery()
            .AsNoTracking()
            .FirstAsync(x => x.Id == id);

        return ApiResponse<BookLocationResponse>.Success(
            MapToBookLocationResponse(updatedLocation),
            "Kitap konumu başarıyla güncellendi.");
    }

    public async Task<ApiResponse<bool>> DeleteBookLocationAsync(int id)
    {
        var location = await _context.KitapKonumlari.FirstOrDefaultAsync(x => x.Id == id);

        if (location is null)
        {
            return ApiResponse<bool>.Fail("Silinecek kitap konumu bulunamadı.");
        }

        location.AktifMi = false;
        location.GuncellemeTarihi = DateTime.Now;

        await _context.SaveChangesAsync();

        return ApiResponse<bool>.Success(true, "Kitap konumu başarıyla pasife alındı.");
    }

    private IQueryable<KitapKonum> GetBookLocationQuery()
    {
        return _context.KitapKonumlari
            .Include(x => x.Kitap)
            .Include(x => x.Raf)
                .ThenInclude(x => x.Dolap)
                    .ThenInclude(x => x.YerlesimBolumu);
    }

    private static BookLocationResponse MapToBookLocationResponse(KitapKonum location)
    {
        return new BookLocationResponse
        {
            Id = location.Id,
            KitapId = location.KitapId,
            KitapAdi = location.Kitap.KitapAdi,
            RafId = location.RafId,
            RafAdi = location.Raf.RafAdi,
            DolapId = location.Raf.DolapId,
            DolapAdi = location.Raf.Dolap.DolapAdi,
            YerlesimBolumuId = location.Raf.Dolap.YerlesimBolumuId,
            YerlesimBolumuAdi = location.Raf.Dolap.YerlesimBolumu.BolumAdi,
            KonumKodu = location.KonumKodu,
            TamKonum = location.Raf.Dolap.YerlesimBolumu.BolumAdi + " / " +
                       location.Raf.Dolap.DolapAdi + " / " +
                       location.Raf.RafAdi,
            Aciklama = location.Aciklama,
            AktifMi = location.AktifMi
        };
    }

    private async Task<List<string>> ValidateCreateAsync(BookLocationCreateRequest request)
    {
        var errors = new List<string>();

        if (!await _context.Kitaplar.AnyAsync(x => x.Id == request.KitapId))
        {
            errors.Add("Seçilen kitap bulunamadı.");
        }

        if (!await _context.Raflar.AnyAsync(x => x.Id == request.RafId))
        {
            errors.Add("Seçilen raf bulunamadı.");
        }

        var exists = await _context.KitapKonumlari
            .AnyAsync(x => x.KitapId == request.KitapId && x.RafId == request.RafId && x.AktifMi);

        if (exists)
        {
            errors.Add("Bu kitap zaten seçilen rafta kayıtlı.");
        }

        return errors;
    }

    private async Task<List<string>> ValidateUpdateAsync(int id, int kitapId, BookLocationUpdateRequest request)
    {
        var errors = new List<string>();

        if (!await _context.Raflar.AnyAsync(x => x.Id == request.RafId))
        {
            errors.Add("Seçilen raf bulunamadı.");
        }

        var duplicateExists = await _context.KitapKonumlari
            .AnyAsync(x =>
                x.Id != id &&
                x.KitapId == kitapId &&
                x.RafId == request.RafId &&
                x.AktifMi);

        if (duplicateExists)
        {
            errors.Add("Bu kitap için seçilen rafta zaten aktif bir konum kaydı var.");
        }

        return errors;
    }

    private static string? NormalizeNullable(string? value)
    {
        return string.IsNullOrWhiteSpace(value)
            ? null
            : value.Trim();
    }
}