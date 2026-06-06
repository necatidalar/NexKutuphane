namespace NexKutuphane.Contracts.Locations;

public class LocationSectionResponse
{
    public int Id { get; set; }

    public string BolumAdi { get; set; } = string.Empty;

    public string? BolumKodu { get; set; }

    public string? Aciklama { get; set; }

    public bool AktifMi { get; set; }
}