using NexKutuphane.Domain.Common;
using NexKutuphane.Domain.Enums;

namespace NexKutuphane.Domain.Entities;

public class OduncIslem : BaseEntity
{
    public int UyeId { get; set; }

    public Uye Uye { get; set; } = null!;

    public int KitapKopyaId { get; set; }

    public KitapKopya KitapKopya { get; set; } = null!;

    public DateTime OduncTarihi { get; set; } = DateTime.Now;

    public DateTime SonTeslimTarihi { get; set; }

    public DateTime? IadeTarihi { get; set; }

    public OduncDurumu Durum { get; set; } = OduncDurumu.Oduncte;

    public int SureUzatmaSayisi { get; set; }

    public decimal? CezaTutari { get; set; }

    public string? Aciklama { get; set; }

    public int? OduncVerenKullaniciId { get; set; }

    public Kullanici? OduncVerenKullanici { get; set; }

    public int? IadeAlanKullaniciId { get; set; }

    public Kullanici? IadeAlanKullanici { get; set; }
}