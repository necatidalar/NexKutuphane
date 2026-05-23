using Microsoft.EntityFrameworkCore;
using NexKutuphane.Application.Abstractions;
using NexKutuphane.Contracts.Authors;
using NexKutuphane.Contracts.Common;
using NexKutuphane.Infrastructure.Persistence.Context;

namespace NexKutuphane.Infrastructure.Services;

public class AuthorService : IAuthorService
{
    private readonly AppDbContext _context;

    public AuthorService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ApiResponse<List<AuthorListResponse>>> GetAllAsync()
    {
        var authors = await _context.Yazarlar
            .AsNoTracking()
            .OrderBy(x => x.Ad)
            .ThenBy(x => x.Soyad)
            .Select(x => new AuthorListResponse
            {
                Id = x.Id,
                Ad = x.Ad,
                Soyad = x.Soyad,
                AdSoyad = x.Ad + " " + x.Soyad,
                Ulke = x.Ulke,
                AktifMi = x.AktifMi
            })
            .ToListAsync();

        return ApiResponse<List<AuthorListResponse>>.Success(
            authors,
            "Yazar listesi başarıyla getirildi.");
    }
}