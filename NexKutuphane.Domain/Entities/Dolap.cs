using NexKutuphane.Domain.Common;

namespace NexKutuphane.Domain.Entities;

public class Dolap : BaseEntity
{
    public string DolapAdi { get; set; } = string.Empty;

    public string? DolapKodu { get; set; }

    public string? Aciklama { get; set; }

    public int YerlesimBolumuId { get; set; }

    public YerlesimBolumu YerlesimBolumu { get; set; } = null!;

    public ICollection<Raf> Raflar { get; set; } = new List<Raf>();
}