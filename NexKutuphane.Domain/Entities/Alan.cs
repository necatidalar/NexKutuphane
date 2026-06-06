using NexKutuphane.Domain.Common;

namespace NexKutuphane.Domain.Entities;

public class Alan : BaseEntity
{
    public string AlanAdi { get; set; } = string.Empty;

    public string? Aciklama { get; set; }

    public int? BolumId { get; set; }

    public Bolum? Bolum { get; set; }

    public ICollection<Uye> Uyeler { get; set; } = new List<Uye>();
}