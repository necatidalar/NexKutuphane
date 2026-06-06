namespace NexKutuphane.Contracts.Locations;

public class BookLocationCreateRequest
{
    public int KitapId { get; set; }

    public int RafId { get; set; }

    public string? KonumKodu { get; set; }

    public string? Aciklama { get; set; }
}