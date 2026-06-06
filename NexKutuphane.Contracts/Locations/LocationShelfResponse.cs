namespace NexKutuphane.Contracts.Locations;

public class LocationShelfResponse
{
    public int Id { get; set; }

    public string RafAdi { get; set; } = string.Empty;

    public string? RafKodu { get; set; }

    public int SiraNo { get; set; }

    public int DolapId { get; set; }

    public string DolapAdi { get; set; } = string.Empty;

    public int YerlesimBolumuId { get; set; }

    public string YerlesimBolumuAdi { get; set; } = string.Empty;

    public string TamKonum { get; set; } = string.Empty;

    public bool AktifMi { get; set; }
}