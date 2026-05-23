using NexKutuphane.Domain.Common;

namespace NexKutuphane.Domain.Entities;

public class Yayinevi : BaseEntity
{
    public string YayineviAdi { get; set; } = string.Empty;

    public string? Telefon { get; set; }

    public string? Eposta { get; set; }

    public string? WebSitesi { get; set; }

    public string? Adres { get; set; }

    public string? Aciklama { get; set; }

    public ICollection<Kitap> Kitaplar { get; set; } = new List<Kitap>();
}