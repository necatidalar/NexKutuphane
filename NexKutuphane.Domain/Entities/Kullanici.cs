using NexKutuphane.Domain.Common;

namespace NexKutuphane.Domain.Entities;

public class Kullanici : BaseEntity
{
    public string KullaniciAdi { get; set; } = string.Empty;

    public string SifreHash { get; set; } = string.Empty;

    public string Ad { get; set; } = string.Empty;

    public string Soyad { get; set; } = string.Empty;

    public string? Eposta { get; set; }

    public string? Telefon { get; set; }

    public DateTime? SonGirisTarihi { get; set; }

    public ICollection<KullaniciRol> KullaniciRolleri { get; set; } = new List<KullaniciRol>();
}