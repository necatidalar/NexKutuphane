namespace NexKutuphane.Contracts.Locations;

public class BookLocationUpdateRequest
{
    public int RafId { get; set; }

    public string? KonumKodu { get; set; }

    public string? Aciklama { get; set; }

    public bool AktifMi { get; set; } = true;
}