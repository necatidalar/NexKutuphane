namespace NexKutuphane.Domain.Entities;

public class KitapYazar
{
    public int KitapId { get; set; }

    public Kitap Kitap { get; set; } = null!;

    public int YazarId { get; set; }

    public Yazar Yazar { get; set; } = null!;
}