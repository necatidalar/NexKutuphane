using NexKutuphane.Domain.Common;

namespace NexKutuphane.Domain.Entities;

public class Sube : BaseEntity
{
    public string SubeAdi { get; set; } = string.Empty;

    public ICollection<Uye> Uyeler { get; set; } = new List<Uye>();
}