using NexKutuphane.Domain.Common;
using NexKutuphane.Domain.Enums;

namespace NexKutuphane.Domain.Entities;

public class Kitap : BaseEntity
{
    public string KitapAdi { get; set; } = string.Empty;

    public string? Barkod { get; set; }

    public string? DemirbasNo { get; set; }

    public string? ISBN { get; set; }

    public int? YayinYili { get; set; }

    public int? BaskiYili { get; set; }

    public int? SayfaSayisi { get; set; }

    public int StokAdedi { get; set; }

    public KitapDurumu Durum { get; set; } = KitapDurumu.Musait;

    public string? Aciklama { get; set; }

    public int? YayineviId { get; set; }

    public Yayinevi? Yayinevi { get; set; }

    public int? KategoriId { get; set; }

    public Kategori? Kategori { get; set; }

    public int? OrijinalDilId { get; set; }

    public Dil? OrijinalDil { get; set; }

    public int? CeviriDilId { get; set; }

    public Dil? CeviriDil { get; set; }

    public string? CevirmenAdi { get; set; }

    public bool CeviriMi { get; set; }

    public ICollection<KitapYazar> KitapYazarlari { get; set; } = new List<KitapYazar>();
}