namespace NexKutuphane.Contracts.Locations;

public class BookLocationResponse
{
    public int Id { get; set; }

    public int KitapId { get; set; }

    public string KitapAdi { get; set; } = string.Empty;

    public int RafId { get; set; }

    public string RafAdi { get; set; } = string.Empty;

    public int DolapId { get; set; }

    public string DolapAdi { get; set; } = string.Empty;

    public int YerlesimBolumuId { get; set; }

    public string YerlesimBolumuAdi { get; set; } = string.Empty;

    public string? KonumKodu { get; set; }

    public string TamKonum { get; set; } = string.Empty;

    public string? Aciklama { get; set; }

    public bool AktifMi { get; set; }
}