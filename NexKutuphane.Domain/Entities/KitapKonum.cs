using NexKutuphane.Domain.Common;

namespace NexKutuphane.Domain.Entities;

public class KitapKonum : BaseEntity
{
    public int KitapId { get; set; }

    public Kitap Kitap { get; set; } = null!;

    public int RafId { get; set; }

    public Raf Raf { get; set; } = null!;

    public string? KonumKodu { get; set; }

    public string? Aciklama { get; set; }
}