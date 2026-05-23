using NexKutuphane.Domain.Common;

namespace NexKutuphane.Domain.Entities;

public class Yazar : BaseEntity
{
    public string Ad { get; set; } = string.Empty;

    public string Soyad { get; set; } = string.Empty;

    public DateTime? DogumTarihi { get; set; }

    public DateTime? OlumTarihi { get; set; }

    public string? Ulke { get; set; }

    public string? Biyografi { get; set; }

    public ICollection<KitapYazar> KitapYazarlari { get; set; } = new List<KitapYazar>();
}