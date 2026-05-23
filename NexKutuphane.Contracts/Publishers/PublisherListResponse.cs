namespace NexKutuphane.Contracts.Publishers;

public class PublisherListResponse
{
    public int Id { get; set; }

    public string YayineviAdi { get; set; } = string.Empty;

    public string? Telefon { get; set; }

    public string? Eposta { get; set; }

    public string? WebSitesi { get; set; }

    public bool AktifMi { get; set; }
}