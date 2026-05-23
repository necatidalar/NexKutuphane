using NexKutuphane.Domain.Common;

namespace NexKutuphane.Domain.Entities;

public class Dil : BaseEntity
{
    public string DilAdi { get; set; } = string.Empty;

    public string? DilKodu { get; set; }

    public ICollection<Kitap> OrijinalDilKitaplari { get; set; } = new List<Kitap>();

    public ICollection<Kitap> CeviriDilKitaplari { get; set; } = new List<Kitap>();
}