using NexKutuphane.Domain.Common;
using NexKutuphane.Domain.Enums;

namespace NexKutuphane.Domain.Entities;

public class Uye : BaseEntity
{
    public string Ad { get; set; } = string.Empty;

    public string Soyad { get; set; } = string.Empty;

    public string? OkulNo { get; set; }

    public string? KimlikNo { get; set; }

    public DateTime? DogumTarihi { get; set; }

    public string? Telefon { get; set; }

    public string? Eposta { get; set; }

    public string? Adres { get; set; }

    public DateTime KayitTarihi { get; set; } = DateTime.Now;

    public UyeDurumu Durum { get; set; } = UyeDurumu.Aktif;

    public int? UyeTuruId { get; set; }

    public UyeTuru? UyeTuru { get; set; }

    public int? SinifId { get; set; }

    public Sinif? Sinif { get; set; }

    public int? SubeId { get; set; }

    public Sube? Sube { get; set; }

    public int? BolumId { get; set; }

    public Bolum? Bolum { get; set; }

    public int? AlanId { get; set; }

    public Alan? Alan { get; set; }

    public string? VeliAdSoyad { get; set; }

    public string? VeliTelefon { get; set; }

    public string? VeliYakinlik { get; set; }

    public string? Aciklama { get; set; }

    public string AdSoyad => $"{Ad} {Soyad}";
}