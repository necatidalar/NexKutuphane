using NexKutuphane.Domain.Common;

namespace NexKutuphane.Domain.Entities;

public class Bolum : BaseEntity
{
    public string BolumAdi { get; set; } = string.Empty;

    public string? Aciklama { get; set; }

    public ICollection<Alan> Alanlar { get; set; } = new List<Alan>();

    public ICollection<Uye> Uyeler { get; set; } = new List<Uye>();
}