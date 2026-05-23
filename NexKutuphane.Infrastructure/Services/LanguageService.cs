using Microsoft.EntityFrameworkCore;
using NexKutuphane.Application.Abstractions;
using NexKutuphane.Contracts.Common;
using NexKutuphane.Contracts.Languages;
using NexKutuphane.Infrastructure.Persistence.Context;

namespace NexKutuphane.Infrastructure.Services;

public class LanguageService : ILanguageService
{
    private readonly AppDbContext _context;

    public LanguageService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ApiResponse<List<LanguageListResponse>>> GetAllAsync()
    {
        var languages = await _context.Diller
            .AsNoTracking()
            .OrderBy(x => x.DilAdi)
            .Select(x => new LanguageListResponse
            {
                Id = x.Id,
                DilAdi = x.DilAdi,
                DilKodu = x.DilKodu,
                AktifMi = x.AktifMi
            })
            .ToListAsync();

        return ApiResponse<List<LanguageListResponse>>.Success(
            languages,
            "Dil listesi başarıyla getirildi.");
    }
}