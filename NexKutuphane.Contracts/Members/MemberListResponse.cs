namespace NexKutuphane.Contracts.Members;

public class MemberListResponse
{
    public int Id { get; set; }

    public string Ad { get; set; } = string.Empty;

    public string Soyad { get; set; } = string.Empty;

    public string AdSoyad { get; set; } = string.Empty;

    public string? OkulNo { get; set; }

    public string? Telefon { get; set; }

    public string? Eposta { get; set; }

    public string? UyeTuruAdi { get; set; }

    public string? SinifAdi { get; set; }

    public string? SubeAdi { get; set; }

    public string? BolumAdi { get; set; }

    public string? AlanAdi { get; set; }

    public string Durum { get; set; } = string.Empty;

    public bool AktifMi { get; set; }
}