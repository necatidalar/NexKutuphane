using Microsoft.EntityFrameworkCore;
using NexKutuphane.Application.Abstractions;
using NexKutuphane.Contracts.Common;
using NexKutuphane.Contracts.Members;
using NexKutuphane.Domain.Entities;
using NexKutuphane.Domain.Enums;
using NexKutuphane.Infrastructure.Persistence.Context;

namespace NexKutuphane.Infrastructure.Services;

public class MemberService : IMemberService
{
    private readonly AppDbContext _context;

    public MemberService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ApiResponse<List<MemberListResponse>>> GetAllAsync()
    {
        var members = await GetMemberQuery()
            .AsNoTracking()
            .OrderBy(x => x.Ad)
            .ThenBy(x => x.Soyad)
            .ToListAsync();

        var result = members.Select(MapToListResponse).ToList();

        return ApiResponse<List<MemberListResponse>>.Success(
            result,
            "Üye listesi başarıyla getirildi.");
    }

    public async Task<ApiResponse<MemberDetailResponse>> GetByIdAsync(int id)
    {
        var member = await GetMemberQuery()
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);

        if (member is null)
        {
            return ApiResponse<MemberDetailResponse>.Fail("Üye bulunamadı.");
        }

        return ApiResponse<MemberDetailResponse>.Success(
            MapToDetailResponse(member),
            "Üye detayı başarıyla getirildi.");
    }

    public async Task<ApiResponse<MemberDetailResponse>> CreateAsync(MemberCreateRequest request)
    {
        var errors = await ValidateCreateAsync(request);

        if (errors.Any())
        {
            return ApiResponse<MemberDetailResponse>.Fail(errors);
        }

        var member = new Uye
        {
            Ad = request.Ad.Trim(),
            Soyad = request.Soyad.Trim(),
            OkulNo = NormalizeNullable(request.OkulNo),
            KimlikNo = NormalizeNullable(request.KimlikNo),
            DogumTarihi = request.DogumTarihi,
            Telefon = NormalizeNullable(request.Telefon),
            Eposta = NormalizeNullable(request.Eposta),
            Adres = NormalizeNullable(request.Adres),
            KayitTarihi = DateTime.Now,
            Durum = (UyeDurumu)request.DurumId,
            UyeTuruId = request.UyeTuruId,
            SinifId = request.SinifId,
            SubeId = request.SubeId,
            BolumId = request.BolumId,
            AlanId = request.AlanId,
            VeliAdSoyad = NormalizeNullable(request.VeliAdSoyad),
            VeliTelefon = NormalizeNullable(request.VeliTelefon),
            VeliYakinlik = NormalizeNullable(request.VeliYakinlik),
            Aciklama = NormalizeNullable(request.Aciklama),
            AktifMi = true,
            OlusturmaTarihi = DateTime.Now
        };

        await _context.Uyeler.AddAsync(member);
        await _context.SaveChangesAsync();

        var createdMember = await GetMemberQuery()
            .AsNoTracking()
            .FirstAsync(x => x.Id == member.Id);

        return ApiResponse<MemberDetailResponse>.Success(
            MapToDetailResponse(createdMember),
            "Üye başarıyla eklendi.");
    }

    public async Task<ApiResponse<MemberDetailResponse>> UpdateAsync(int id, MemberUpdateRequest request)
    {
        var member = await _context.Uyeler.FirstOrDefaultAsync(x => x.Id == id);

        if (member is null)
        {
            return ApiResponse<MemberDetailResponse>.Fail("Güncellenecek üye bulunamadı.");
        }

        var errors = await ValidateUpdateAsync(id, request);

        if (errors.Any())
        {
            return ApiResponse<MemberDetailResponse>.Fail(errors);
        }

        member.Ad = request.Ad.Trim();
        member.Soyad = request.Soyad.Trim();
        member.OkulNo = NormalizeNullable(request.OkulNo);
        member.KimlikNo = NormalizeNullable(request.KimlikNo);
        member.DogumTarihi = request.DogumTarihi;
        member.Telefon = NormalizeNullable(request.Telefon);
        member.Eposta = NormalizeNullable(request.Eposta);
        member.Adres = NormalizeNullable(request.Adres);
        member.Durum = (UyeDurumu)request.DurumId;
        member.UyeTuruId = request.UyeTuruId;
        member.SinifId = request.SinifId;
        member.SubeId = request.SubeId;
        member.BolumId = request.BolumId;
        member.AlanId = request.AlanId;
        member.VeliAdSoyad = NormalizeNullable(request.VeliAdSoyad);
        member.VeliTelefon = NormalizeNullable(request.VeliTelefon);
        member.VeliYakinlik = NormalizeNullable(request.VeliYakinlik);
        member.Aciklama = NormalizeNullable(request.Aciklama);
        member.AktifMi = request.AktifMi;
        member.GuncellemeTarihi = DateTime.Now;

        await _context.SaveChangesAsync();

        var updatedMember = await GetMemberQuery()
            .AsNoTracking()
            .FirstAsync(x => x.Id == id);

        return ApiResponse<MemberDetailResponse>.Success(
            MapToDetailResponse(updatedMember),
            "Üye başarıyla güncellendi.");
    }

    public async Task<ApiResponse<bool>> DeleteAsync(int id)
    {
        var member = await _context.Uyeler.FirstOrDefaultAsync(x => x.Id == id);

        if (member is null)
        {
            return ApiResponse<bool>.Fail("Silinecek üye bulunamadı.");
        }

        member.AktifMi = false;
        member.Durum = UyeDurumu.Pasif;
        member.GuncellemeTarihi = DateTime.Now;

        await _context.SaveChangesAsync();

        return ApiResponse<bool>.Success(true, "Üye başarıyla pasife alındı.");
    }

    public async Task<ApiResponse<MemberLookupsResponse>> GetLookupsAsync()
    {
        var result = new MemberLookupsResponse
        {
            UyeTurleri = await _context.UyeTurleri
                .AsNoTracking()
                .Where(x => x.AktifMi)
                .OrderBy(x => x.UyeTuruAdi)
                .Select(x => new MemberLookupItemResponse
                {
                    Id = x.Id,
                    Ad = x.UyeTuruAdi
                })
                .ToListAsync(),

            Siniflar = await _context.Siniflar
                .AsNoTracking()
                .Where(x => x.AktifMi)
                .OrderBy(x => x.Seviye)
                .Select(x => new MemberLookupItemResponse
                {
                    Id = x.Id,
                    Ad = x.SinifAdi
                })
                .ToListAsync(),

            Subeler = await _context.Subeler
                .AsNoTracking()
                .Where(x => x.AktifMi)
                .OrderBy(x => x.SubeAdi)
                .Select(x => new MemberLookupItemResponse
                {
                    Id = x.Id,
                    Ad = x.SubeAdi
                })
                .ToListAsync(),

            Bolumler = await _context.Bolumler
                .AsNoTracking()
                .Where(x => x.AktifMi)
                .OrderBy(x => x.BolumAdi)
                .Select(x => new MemberLookupItemResponse
                {
                    Id = x.Id,
                    Ad = x.BolumAdi
                })
                .ToListAsync(),

            Alanlar = await _context.Alanlar
                .AsNoTracking()
                .Where(x => x.AktifMi)
                .OrderBy(x => x.AlanAdi)
                .Select(x => new MemberLookupItemResponse
                {
                    Id = x.Id,
                    Ad = x.AlanAdi,
                    ParentId = x.BolumId
                })
                .ToListAsync(),

            Durumlar = Enum.GetValues<UyeDurumu>()
                .Select(x => new MemberLookupItemResponse
                {
                    Id = (int)x,
                    Ad = x.ToString()
                })
                .ToList()
        };

        return ApiResponse<MemberLookupsResponse>.Success(
            result,
            "Üye seçim listeleri başarıyla getirildi.");
    }

    private IQueryable<Uye> GetMemberQuery()
    {
        return _context.Uyeler
            .Include(x => x.UyeTuru)
            .Include(x => x.Sinif)
            .Include(x => x.Sube)
            .Include(x => x.Bolum)
            .Include(x => x.Alan);
    }

    private static MemberListResponse MapToListResponse(Uye member)
    {
        return new MemberListResponse
        {
            Id = member.Id,
            Ad = member.Ad,
            Soyad = member.Soyad,
            AdSoyad = $"{member.Ad} {member.Soyad}",
            OkulNo = member.OkulNo,
            Telefon = member.Telefon,
            Eposta = member.Eposta,
            UyeTuruAdi = member.UyeTuru?.UyeTuruAdi,
            SinifAdi = member.Sinif?.SinifAdi,
            SubeAdi = member.Sube?.SubeAdi,
            BolumAdi = member.Bolum?.BolumAdi,
            AlanAdi = member.Alan?.AlanAdi,
            Durum = member.Durum.ToString(),
            AktifMi = member.AktifMi
        };
    }

    private static MemberDetailResponse MapToDetailResponse(Uye member)
    {
        return new MemberDetailResponse
        {
            Id = member.Id,
            Ad = member.Ad,
            Soyad = member.Soyad,
            AdSoyad = $"{member.Ad} {member.Soyad}",
            OkulNo = member.OkulNo,
            KimlikNo = member.KimlikNo,
            DogumTarihi = member.DogumTarihi,
            Telefon = member.Telefon,
            Eposta = member.Eposta,
            Adres = member.Adres,
            KayitTarihi = member.KayitTarihi,
            DurumId = (int)member.Durum,
            Durum = member.Durum.ToString(),
            UyeTuruId = member.UyeTuruId,
            UyeTuruAdi = member.UyeTuru?.UyeTuruAdi,
            SinifId = member.SinifId,
            SinifAdi = member.Sinif?.SinifAdi,
            SubeId = member.SubeId,
            SubeAdi = member.Sube?.SubeAdi,
            BolumId = member.BolumId,
            BolumAdi = member.Bolum?.BolumAdi,
            AlanId = member.AlanId,
            AlanAdi = member.Alan?.AlanAdi,
            VeliAdSoyad = member.VeliAdSoyad,
            VeliTelefon = member.VeliTelefon,
            VeliYakinlik = member.VeliYakinlik,
            Aciklama = member.Aciklama,
            AktifMi = member.AktifMi
        };
    }

    private async Task<List<string>> ValidateCreateAsync(MemberCreateRequest request)
    {
        var errors = ValidateCommonFields(
            request.Ad,
            request.Soyad,
            request.DurumId);

        await ValidateRelationsAsync(
            errors,
            request.UyeTuruId,
            request.SinifId,
            request.SubeId,
            request.BolumId,
            request.AlanId);

        await ValidateUniqueOkulNoAsync(
            errors,
            null,
            request.OkulNo);

        return errors;
    }

    private async Task<List<string>> ValidateUpdateAsync(int id, MemberUpdateRequest request)
    {
        var errors = ValidateCommonFields(
            request.Ad,
            request.Soyad,
            request.DurumId);

        await ValidateRelationsAsync(
            errors,
            request.UyeTuruId,
            request.SinifId,
            request.SubeId,
            request.BolumId,
            request.AlanId);

        await ValidateUniqueOkulNoAsync(
            errors,
            id,
            request.OkulNo);

        return errors;
    }

    private static List<string> ValidateCommonFields(
        string ad,
        string soyad,
        int durumId)
    {
        var errors = new List<string>();

        if (string.IsNullOrWhiteSpace(ad))
        {
            errors.Add("Ad zorunludur.");
        }

        if (string.IsNullOrWhiteSpace(soyad))
        {
            errors.Add("Soyad zorunludur.");
        }

        if (ad.Length > 100)
        {
            errors.Add("Ad en fazla 100 karakter olabilir.");
        }

        if (soyad.Length > 100)
        {
            errors.Add("Soyad en fazla 100 karakter olabilir.");
        }

        if (!Enum.IsDefined(typeof(UyeDurumu), durumId))
        {
            errors.Add("Geçersiz üye durumu seçildi.");
        }

        return errors;
    }

    private async Task ValidateRelationsAsync(
        List<string> errors,
        int? uyeTuruId,
        int? sinifId,
        int? subeId,
        int? bolumId,
        int? alanId)
    {
        if (uyeTuruId.HasValue && !await _context.UyeTurleri.AnyAsync(x => x.Id == uyeTuruId.Value))
        {
            errors.Add("Seçilen üye türü bulunamadı.");
        }

        if (sinifId.HasValue && !await _context.Siniflar.AnyAsync(x => x.Id == sinifId.Value))
        {
            errors.Add("Seçilen sınıf bulunamadı.");
        }

        if (subeId.HasValue && !await _context.Subeler.AnyAsync(x => x.Id == subeId.Value))
        {
            errors.Add("Seçilen şube bulunamadı.");
        }

        if (bolumId.HasValue && !await _context.Bolumler.AnyAsync(x => x.Id == bolumId.Value))
        {
            errors.Add("Seçilen bölüm bulunamadı.");
        }

        if (alanId.HasValue && !await _context.Alanlar.AnyAsync(x => x.Id == alanId.Value))
        {
            errors.Add("Seçilen alan bulunamadı.");
        }

        if (alanId.HasValue && bolumId.HasValue)
        {
            var alanBolumeAitMi = await _context.Alanlar
                .AnyAsync(x => x.Id == alanId.Value && x.BolumId == bolumId.Value);

            if (!alanBolumeAitMi)
            {
                errors.Add("Seçilen alan, seçilen bölüme ait değildir.");
            }
        }
    }

    private async Task ValidateUniqueOkulNoAsync(
        List<string> errors,
        int? currentMemberId,
        string? okulNo)
    {
        okulNo = NormalizeNullable(okulNo);

        if (string.IsNullOrWhiteSpace(okulNo))
        {
            return;
        }

        var exists = await _context.Uyeler
            .AnyAsync(x => x.OkulNo == okulNo && (!currentMemberId.HasValue || x.Id != currentMemberId.Value));

        if (exists)
        {
            errors.Add("Bu okul numarası başka bir üyede kullanılıyor.");
        }
    }

    private static string? NormalizeNullable(string? value)
    {
        return string.IsNullOrWhiteSpace(value)
            ? null
            : value.Trim();
    }
}