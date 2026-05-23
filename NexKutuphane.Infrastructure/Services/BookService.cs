using Microsoft.EntityFrameworkCore;
using NexKutuphane.Application.Abstractions;
using NexKutuphane.Contracts.Books;
using NexKutuphane.Contracts.Common;
using NexKutuphane.Domain.Entities;
using NexKutuphane.Domain.Enums;
using NexKutuphane.Infrastructure.Persistence.Context;

namespace NexKutuphane.Infrastructure.Services;

public class BookService : IBookService
{
    private readonly AppDbContext _context;

    public BookService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ApiResponse<List<BookListResponse>>> GetAllAsync()
    {
        var books = await GetBookQuery()
            .AsNoTracking()
            .OrderBy(x => x.KitapAdi)
            .ToListAsync();

        var result = books.Select(MapToListResponse).ToList();

        return ApiResponse<List<BookListResponse>>.Success(
            result,
            "Kitap listesi başarıyla getirildi.");
    }

    public async Task<ApiResponse<BookDetailResponse>> GetByIdAsync(int id)
    {
        var book = await GetBookQuery()
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);

        if (book is null)
        {
            return ApiResponse<BookDetailResponse>.Fail("Kitap bulunamadı.");
        }

        return ApiResponse<BookDetailResponse>.Success(
            MapToDetailResponse(book),
            "Kitap detayı başarıyla getirildi.");
    }

    public async Task<ApiResponse<BookDetailResponse>> CreateAsync(BookCreateRequest request)
    {
        var validationErrors = await ValidateCreateAsync(request);

        if (validationErrors.Any())
        {
            return ApiResponse<BookDetailResponse>.Fail(validationErrors);
        }

        var durum = (KitapDurumu)request.DurumId;

        var kitap = new Kitap
        {
            KitapAdi = request.KitapAdi.Trim(),
            Barkod = NormalizeNullable(request.Barkod),
            DemirbasNo = NormalizeNullable(request.DemirbasNo),
            ISBN = NormalizeNullable(request.ISBN),
            YayinYili = request.YayinYili,
            BaskiYili = request.BaskiYili,
            SayfaSayisi = request.SayfaSayisi,
            StokAdedi = request.StokAdedi,
            Durum = durum,
            Aciklama = NormalizeNullable(request.Aciklama),
            YayineviId = request.YayineviId,
            KategoriId = request.KategoriId,
            OrijinalDilId = request.OrijinalDilId,
            CeviriDilId = request.CeviriMi ? request.CeviriDilId : null,
            CevirmenAdi = request.CeviriMi ? NormalizeNullable(request.CevirmenAdi) : null,
            CeviriMi = request.CeviriMi,
            AktifMi = true,
            OlusturmaTarihi = DateTime.Now
        };

        var yazarIdleri = request.YazarIdleri.Distinct().ToList();

        foreach (var yazarId in yazarIdleri)
        {
            kitap.KitapYazarlari.Add(new KitapYazar
            {
                YazarId = yazarId
            });
        }

        await _context.Kitaplar.AddAsync(kitap);
        await _context.SaveChangesAsync();

        var createdBook = await GetBookQuery()
            .AsNoTracking()
            .FirstAsync(x => x.Id == kitap.Id);

        return ApiResponse<BookDetailResponse>.Success(
            MapToDetailResponse(createdBook),
            "Kitap başarıyla eklendi.");
    }

    public async Task<ApiResponse<BookDetailResponse>> UpdateAsync(int id, BookUpdateRequest request)
    {
        var kitap = await _context.Kitaplar
            .Include(x => x.KitapYazarlari)
            .FirstOrDefaultAsync(x => x.Id == id);

        if (kitap is null)
        {
            return ApiResponse<BookDetailResponse>.Fail("Güncellenecek kitap bulunamadı.");
        }

        var validationErrors = await ValidateUpdateAsync(id, request);

        if (validationErrors.Any())
        {
            return ApiResponse<BookDetailResponse>.Fail(validationErrors);
        }

        kitap.KitapAdi = request.KitapAdi.Trim();
        kitap.Barkod = NormalizeNullable(request.Barkod);
        kitap.DemirbasNo = NormalizeNullable(request.DemirbasNo);
        kitap.ISBN = NormalizeNullable(request.ISBN);
        kitap.YayinYili = request.YayinYili;
        kitap.BaskiYili = request.BaskiYili;
        kitap.SayfaSayisi = request.SayfaSayisi;
        kitap.StokAdedi = request.StokAdedi;
        kitap.Durum = (KitapDurumu)request.DurumId;
        kitap.Aciklama = NormalizeNullable(request.Aciklama);
        kitap.YayineviId = request.YayineviId;
        kitap.KategoriId = request.KategoriId;
        kitap.OrijinalDilId = request.OrijinalDilId;
        kitap.CeviriDilId = request.CeviriMi ? request.CeviriDilId : null;
        kitap.CevirmenAdi = request.CeviriMi ? NormalizeNullable(request.CevirmenAdi) : null;
        kitap.CeviriMi = request.CeviriMi;
        kitap.AktifMi = request.AktifMi;
        kitap.GuncellemeTarihi = DateTime.Now;

        _context.KitapYazarlari.RemoveRange(kitap.KitapYazarlari);

        var yazarIdleri = request.YazarIdleri.Distinct().ToList();

        foreach (var yazarId in yazarIdleri)
        {
            kitap.KitapYazarlari.Add(new KitapYazar
            {
                KitapId = kitap.Id,
                YazarId = yazarId
            });
        }

        await _context.SaveChangesAsync();

        var updatedBook = await GetBookQuery()
            .AsNoTracking()
            .FirstAsync(x => x.Id == id);

        return ApiResponse<BookDetailResponse>.Success(
            MapToDetailResponse(updatedBook),
            "Kitap başarıyla güncellendi.");
    }

    public async Task<ApiResponse<bool>> DeleteAsync(int id)
    {
        var kitap = await _context.Kitaplar.FirstOrDefaultAsync(x => x.Id == id);

        if (kitap is null)
        {
            return ApiResponse<bool>.Fail("Silinecek kitap bulunamadı.");
        }

        kitap.AktifMi = false;
        kitap.GuncellemeTarihi = DateTime.Now;

        await _context.SaveChangesAsync();

        return ApiResponse<bool>.Success(true, "Kitap başarıyla pasife alındı.");
    }

    private IQueryable<Kitap> GetBookQuery()
    {
        return _context.Kitaplar
            .Include(x => x.Kategori)
            .Include(x => x.Yayinevi)
            .Include(x => x.OrijinalDil)
            .Include(x => x.CeviriDil)
            .Include(x => x.KitapYazarlari)
                .ThenInclude(x => x.Yazar);
    }

    private static BookListResponse MapToListResponse(Kitap kitap)
    {
        return new BookListResponse
        {
            Id = kitap.Id,
            KitapAdi = kitap.KitapAdi,
            Barkod = kitap.Barkod,
            DemirbasNo = kitap.DemirbasNo,
            ISBN = kitap.ISBN,
            StokAdedi = kitap.StokAdedi,
            Durum = kitap.Durum.ToString(),
            KategoriAdi = kitap.Kategori?.KategoriAdi,
            YayineviAdi = kitap.Yayinevi?.YayineviAdi,
            OrijinalDilAdi = kitap.OrijinalDil?.DilAdi,
            CeviriDilAdi = kitap.CeviriDil?.DilAdi,
            CeviriMi = kitap.CeviriMi,
            Yazarlar = string.Join(", ", kitap.KitapYazarlari.Select(x => $"{x.Yazar.Ad} {x.Yazar.Soyad}")),
            AktifMi = kitap.AktifMi
        };
    }

    private static BookDetailResponse MapToDetailResponse(Kitap kitap)
    {
        return new BookDetailResponse
        {
            Id = kitap.Id,
            KitapAdi = kitap.KitapAdi,
            Barkod = kitap.Barkod,
            DemirbasNo = kitap.DemirbasNo,
            ISBN = kitap.ISBN,
            YayinYili = kitap.YayinYili,
            BaskiYili = kitap.BaskiYili,
            SayfaSayisi = kitap.SayfaSayisi,
            StokAdedi = kitap.StokAdedi,
            DurumId = (int)kitap.Durum,
            Durum = kitap.Durum.ToString(),
            Aciklama = kitap.Aciklama,
            YayineviId = kitap.YayineviId,
            YayineviAdi = kitap.Yayinevi?.YayineviAdi,
            KategoriId = kitap.KategoriId,
            KategoriAdi = kitap.Kategori?.KategoriAdi,
            OrijinalDilId = kitap.OrijinalDilId,
            OrijinalDilAdi = kitap.OrijinalDil?.DilAdi,
            CeviriDilId = kitap.CeviriDilId,
            CeviriDilAdi = kitap.CeviriDil?.DilAdi,
            CevirmenAdi = kitap.CevirmenAdi,
            CeviriMi = kitap.CeviriMi,
            AktifMi = kitap.AktifMi,
            Yazarlar = kitap.KitapYazarlari
                .Select(x => new BookAuthorResponse
                {
                    Id = x.YazarId,
                    AdSoyad = $"{x.Yazar.Ad} {x.Yazar.Soyad}"
                })
                .ToList()
        };
    }

    private async Task<List<string>> ValidateCreateAsync(BookCreateRequest request)
    {
        var errors = ValidateCommonFields(
            request.KitapAdi,
            request.StokAdedi,
            request.DurumId,
            request.CeviriMi,
            request.CeviriDilId,
            request.YazarIdleri);

        await ValidateRelationsAsync(
            errors,
            request.YayineviId,
            request.KategoriId,
            request.OrijinalDilId,
            request.CeviriDilId,
            request.YazarIdleri);

        await ValidateUniqueFieldsAsync(
            errors,
            null,
            request.Barkod,
            request.DemirbasNo,
            request.ISBN);

        return errors;
    }

    private async Task<List<string>> ValidateUpdateAsync(int id, BookUpdateRequest request)
    {
        var errors = ValidateCommonFields(
            request.KitapAdi,
            request.StokAdedi,
            request.DurumId,
            request.CeviriMi,
            request.CeviriDilId,
            request.YazarIdleri);

        await ValidateRelationsAsync(
            errors,
            request.YayineviId,
            request.KategoriId,
            request.OrijinalDilId,
            request.CeviriDilId,
            request.YazarIdleri);

        await ValidateUniqueFieldsAsync(
            errors,
            id,
            request.Barkod,
            request.DemirbasNo,
            request.ISBN);

        return errors;
    }

    private static List<string> ValidateCommonFields(
        string kitapAdi,
        int stokAdedi,
        int durumId,
        bool ceviriMi,
        int? ceviriDilId,
        List<int> yazarIdleri)
    {
        var errors = new List<string>();

        if (string.IsNullOrWhiteSpace(kitapAdi))
        {
            errors.Add("Kitap adı zorunludur.");
        }

        if (kitapAdi.Length > 200)
        {
            errors.Add("Kitap adı en fazla 200 karakter olabilir.");
        }

        if (stokAdedi < 0)
        {
            errors.Add("Stok adedi 0'dan küçük olamaz.");
        }

        if (!Enum.IsDefined(typeof(KitapDurumu), durumId))
        {
            errors.Add("Geçersiz kitap durumu seçildi.");
        }

        if (ceviriMi && ceviriDilId is null)
        {
            errors.Add("Çeviri kitaplarda çeviri dili seçilmelidir.");
        }

        if (yazarIdleri is null || !yazarIdleri.Any())
        {
            errors.Add("En az bir yazar seçilmelidir.");
        }

        return errors;
    }

    private async Task ValidateRelationsAsync(
        List<string> errors,
        int? yayineviId,
        int? kategoriId,
        int? orijinalDilId,
        int? ceviriDilId,
        List<int> yazarIdleri)
    {
        if (yayineviId.HasValue && !await _context.Yayinevleri.AnyAsync(x => x.Id == yayineviId.Value))
        {
            errors.Add("Seçilen yayınevi bulunamadı.");
        }

        if (kategoriId.HasValue && !await _context.Kategoriler.AnyAsync(x => x.Id == kategoriId.Value))
        {
            errors.Add("Seçilen kategori bulunamadı.");
        }

        if (orijinalDilId.HasValue && !await _context.Diller.AnyAsync(x => x.Id == orijinalDilId.Value))
        {
            errors.Add("Seçilen orijinal dil bulunamadı.");
        }

        if (ceviriDilId.HasValue && !await _context.Diller.AnyAsync(x => x.Id == ceviriDilId.Value))
        {
            errors.Add("Seçilen çeviri dili bulunamadı.");
        }

        if (yazarIdleri is not null && yazarIdleri.Any())
        {
            var distinctYazarIdleri = yazarIdleri.Distinct().ToList();

            var existingAuthorCount = await _context.Yazarlar
                .CountAsync(x => distinctYazarIdleri.Contains(x.Id));

            if (existingAuthorCount != distinctYazarIdleri.Count)
            {
                errors.Add("Seçilen yazarlardan biri veya birkaçı bulunamadı.");
            }
        }
    }

    private async Task ValidateUniqueFieldsAsync(
        List<string> errors,
        int? currentBookId,
        string? barkod,
        string? demirbasNo,
        string? isbn)
    {
        barkod = NormalizeNullable(barkod);
        demirbasNo = NormalizeNullable(demirbasNo);
        isbn = NormalizeNullable(isbn);

        if (!string.IsNullOrWhiteSpace(barkod))
        {
            var exists = await _context.Kitaplar
                .AnyAsync(x => x.Barkod == barkod && (!currentBookId.HasValue || x.Id != currentBookId.Value));

            if (exists)
            {
                errors.Add("Bu barkod başka bir kitapta kullanılıyor.");
            }
        }

        if (!string.IsNullOrWhiteSpace(demirbasNo))
        {
            var exists = await _context.Kitaplar
                .AnyAsync(x => x.DemirbasNo == demirbasNo && (!currentBookId.HasValue || x.Id != currentBookId.Value));

            if (exists)
            {
                errors.Add("Bu demirbaş numarası başka bir kitapta kullanılıyor.");
            }
        }

        if (!string.IsNullOrWhiteSpace(isbn))
        {
            var exists = await _context.Kitaplar
                .AnyAsync(x => x.ISBN == isbn && (!currentBookId.HasValue || x.Id != currentBookId.Value));

            if (exists)
            {
                errors.Add("Bu ISBN başka bir kitapta kullanılıyor.");
            }
        }
    }

    private static string? NormalizeNullable(string? value)
    {
        return string.IsNullOrWhiteSpace(value)
            ? null
            : value.Trim();
    }
}