using Microsoft.EntityFrameworkCore;
using NexKutuphane.Application.Abstractions;
using NexKutuphane.Contracts.Books;
using NexKutuphane.Contracts.Common;
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
        var books = await _context.Kitaplar
            .AsNoTracking()
            .Include(x => x.Kategori)
            .Include(x => x.Yayinevi)
            .Include(x => x.OrijinalDil)
            .Include(x => x.CeviriDil)
            .Include(x => x.KitapYazarlari)
                .ThenInclude(x => x.Yazar)
            .OrderBy(x => x.KitapAdi)
            .Select(x => new BookListResponse
            {
                Id = x.Id,
                KitapAdi = x.KitapAdi,
                Barkod = x.Barkod,
                DemirbasNo = x.DemirbasNo,
                ISBN = x.ISBN,
                StokAdedi = x.StokAdedi,
                Durum = x.Durum.ToString(),
                KategoriAdi = x.Kategori != null ? x.Kategori.KategoriAdi : null,
                YayineviAdi = x.Yayinevi != null ? x.Yayinevi.YayineviAdi : null,
                OrijinalDilAdi = x.OrijinalDil != null ? x.OrijinalDil.DilAdi : null,
                CeviriDilAdi = x.CeviriDil != null ? x.CeviriDil.DilAdi : null,
                CeviriMi = x.CeviriMi,
                Yazarlar = string.Join(", ", x.KitapYazarlari.Select(y => y.Yazar.Ad + " " + y.Yazar.Soyad)),
                AktifMi = x.AktifMi
            })
            .ToListAsync();

        return ApiResponse<List<BookListResponse>>.Success(
            books,
            "Kitap listesi başarıyla getirildi.");
    }
}