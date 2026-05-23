using Microsoft.EntityFrameworkCore;
using NexKutuphane.Application.Abstractions;
using NexKutuphane.Contracts.Common;
using NexKutuphane.Contracts.Publishers;
using NexKutuphane.Infrastructure.Persistence.Context;

namespace NexKutuphane.Infrastructure.Services;

public class PublisherService : IPublisherService
{
    private readonly AppDbContext _context;

    public PublisherService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ApiResponse<List<PublisherListResponse>>> GetAllAsync()
    {
        var publishers = await _context.Yayinevleri
            .AsNoTracking()
            .OrderBy(x => x.YayineviAdi)
            .Select(x => new PublisherListResponse
            {
                Id = x.Id,
                YayineviAdi = x.YayineviAdi,
                Telefon = x.Telefon,
                Eposta = x.Eposta,
                WebSitesi = x.WebSitesi,
                AktifMi = x.AktifMi
            })
            .ToListAsync();

        return ApiResponse<List<PublisherListResponse>>.Success(
            publishers,
            "Yayınevi listesi başarıyla getirildi.");
    }
}