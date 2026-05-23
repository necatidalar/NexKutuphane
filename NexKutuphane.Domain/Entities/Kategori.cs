using NexKutuphane.Domain.Common;

namespace NexKutuphane.Domain.Entities;

public class Kategori : BaseEntity
{
    public string KategoriAdi { get; set; } = string.Empty;

    public string? KategoriKodu { get; set; }

    public string? Aciklama { get; set; }

    public int? UstKategoriId { get; set; }

    public Kategori? UstKategori { get; set; }

    public ICollection<Kategori> AltKategoriler { get; set; } = new List<Kategori>();

    public ICollection<Kitap> Kitaplar { get; set; } = new List<Kitap>();
}