namespace NexKutuphane.Contracts.Members;

public class MemberUpdateRequest
{
    public string Ad { get; set; } = string.Empty;

    public string Soyad { get; set; } = string.Empty;

    public string? OkulNo { get; set; }

    public string? KimlikNo { get; set; }

    public DateTime? DogumTarihi { get; set; }

    public string? Telefon { get; set; }

    public string? Eposta { get; set; }

    public string? Adres { get; set; }

    public int DurumId { get; set; } = 1;

    public int? UyeTuruId { get; set; }

    public int? SinifId { get; set; }

    public int? SubeId { get; set; }

    public int? BolumId { get; set; }

    public int? AlanId { get; set; }

    public string? VeliAdSoyad { get; set; }

    public string? VeliTelefon { get; set; }

    public string? VeliYakinlik { get; set; }

    public string? Aciklama { get; set; }

    public bool AktifMi { get; set; } = true;
}