namespace NexKutuphane.Contracts.Locations;

public class LocationCabinetResponse
{
    public int Id { get; set; }

    public string DolapAdi { get; set; } = string.Empty;

    public string? DolapKodu { get; set; }

    public int YerlesimBolumuId { get; set; }

    public string YerlesimBolumuAdi { get; set; } = string.Empty;

    public string? Aciklama { get; set; }

    public bool AktifMi { get; set; }
}