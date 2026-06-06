using NexKutuphane.Domain.Common;

namespace NexKutuphane.Domain.Entities;

public class UyeTuru : BaseEntity
{
    public string UyeTuruAdi { get; set; } = string.Empty;

    public string UyeTuruKodu { get; set; } = string.Empty;

    public string? Aciklama { get; set; }

    public ICollection<Uye> Uyeler { get; set; } = new List<Uye>();
}