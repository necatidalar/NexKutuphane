using NexKutuphane.Domain.Common;

namespace NexKutuphane.Domain.Entities;

public class YerlesimBolumu : BaseEntity
{
    public string BolumAdi { get; set; } = string.Empty;

    public string? BolumKodu { get; set; }

    public string? Aciklama { get; set; }

    public ICollection<Dolap> Dolaplar { get; set; } = new List<Dolap>();
}