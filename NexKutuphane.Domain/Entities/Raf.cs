using NexKutuphane.Domain.Common;

namespace NexKutuphane.Domain.Entities;

public class Raf : BaseEntity
{
    public string RafAdi { get; set; } = string.Empty;

    public string? RafKodu { get; set; }

    public int SiraNo { get; set; }

    public string? Aciklama { get; set; }

    public int DolapId { get; set; }

    public Dolap Dolap { get; set; } = null!;

    public ICollection<KitapKonum> KitapKonumlari { get; set; } = new List<KitapKonum>();
    public ICollection<KitapKopya> KitapKopyalari { get; set; } = new List<KitapKopya>();
}