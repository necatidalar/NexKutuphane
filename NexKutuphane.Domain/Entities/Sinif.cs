using NexKutuphane.Domain.Common;

namespace NexKutuphane.Domain.Entities;

public class Sinif : BaseEntity
{
    public string SinifAdi { get; set; } = string.Empty;

    public int Seviye { get; set; }

    public ICollection<Uye> Uyeler { get; set; } = new List<Uye>();
}