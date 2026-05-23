using Microsoft.EntityFrameworkCore;
using NexKutuphane.Application.Abstractions;
using NexKutuphane.Contracts.Categories;
using NexKutuphane.Contracts.Common;
using NexKutuphane.Infrastructure.Persistence.Context;

namespace NexKutuphane.Infrastructure.Services;

public class CategoryService : ICategoryService
{
    private readonly AppDbContext _context;

    public CategoryService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ApiResponse<List<CategoryListResponse>>> GetAllAsync()
    {
        var categories = await _context.Kategoriler
            .AsNoTracking()
            .Include(x => x.UstKategori)
            .OrderBy(x => x.KategoriAdi)
            .Select(x => new CategoryListResponse
            {
                Id = x.Id,
                KategoriAdi = x.KategoriAdi,
                KategoriKodu = x.KategoriKodu,
                Aciklama = x.Aciklama,
                UstKategoriId = x.UstKategoriId,
                UstKategoriAdi = x.UstKategori != null ? x.UstKategori.KategoriAdi : null,
                AktifMi = x.AktifMi
            })
            .ToListAsync();

        return ApiResponse<List<CategoryListResponse>>.Success(
            categories,
            "Kategori listesi başarıyla getirildi.");
    }
}