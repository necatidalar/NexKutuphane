namespace NexKutuphane.Contracts.Books;

public class BookListResponse
{
    public int Id { get; set; }

    public string KitapAdi { get; set; } = string.Empty;

    public string? Barkod { get; set; }

    public string? DemirbasNo { get; set; }

    public string? ISBN { get; set; }

    public int StokAdedi { get; set; }

    public string Durum { get; set; } = string.Empty;

    public string? KategoriAdi { get; set; }

    public string? YayineviAdi { get; set; }

    public string? OrijinalDilAdi { get; set; }

    public string? CeviriDilAdi { get; set; }

    public bool CeviriMi { get; set; }

    public string Yazarlar { get; set; } = string.Empty;

    public bool AktifMi { get; set; }
}