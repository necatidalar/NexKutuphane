namespace NexKutuphane.Contracts.Authors;

public class AuthorListResponse
{
    public int Id { get; set; }

    public string Ad { get; set; } = string.Empty;

    public string Soyad { get; set; } = string.Empty;

    public string AdSoyad { get; set; } = string.Empty;

    public string? Ulke { get; set; }

    public bool AktifMi { get; set; }
}