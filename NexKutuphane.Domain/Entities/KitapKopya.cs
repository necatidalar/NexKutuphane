using NexKutuphane.Domain.Common;
using NexKutuphane.Domain.Enums;

namespace NexKutuphane.Domain.Entities;

public class KitapKopya : BaseEntity
{
    public int KitapId { get; set; }

    public Kitap Kitap { get; set; } = null!;

    public string Barkod { get; set; } = string.Empty;

    public string? DemirbasNo { get; set; }

    public KitapKopyaDurumu Durum { get; set; } = KitapKopyaDurumu.Musait;

    public int? RafId { get; set; }

    public Raf? Raf { get; set; }

    public string? Aciklama { get; set; }

    public ICollection<OduncIslem> OduncIslemleri { get; set; } = new List<OduncIslem>();
}