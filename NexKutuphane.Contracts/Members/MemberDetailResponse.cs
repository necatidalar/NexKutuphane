namespace NexKutuphane.Contracts.Members;

public class MemberDetailResponse
{
    public int Id { get; set; }

    public string Ad { get; set; } = string.Empty;

    public string Soyad { get; set; } = string.Empty;

    public string AdSoyad { get; set; } = string.Empty;

    public string? OkulNo { get; set; }

    public string? KimlikNo { get; set; }

    public DateTime? DogumTarihi { get; set; }

    public string? Telefon { get; set; }

    public string? Eposta { get; set; }

    public string? Adres { get; set; }

    public DateTime KayitTarihi { get; set; }

    public int DurumId { get; set; }

    public string Durum { get; set; } = string.Empty;

    public int? UyeTuruId { get; set; }

    public string? UyeTuruAdi { get; set; }

    public int? SinifId { get; set; }

    public string? SinifAdi { get; set; }

    public int? SubeId { get; set; }

    public string? SubeAdi { get; set; }

    public int? BolumId { get; set; }

    public string? BolumAdi { get; set; }

    public int? AlanId { get; set; }

    public string? AlanAdi { get; set; }

    public string? VeliAdSoyad { get; set; }

    public string? VeliTelefon { get; set; }

    public string? VeliYakinlik { get; set; }

    public string? Aciklama { get; set; }

    public bool AktifMi { get; set; }
}