namespace NexKutuphane.Contracts.Books;

public class BookUpdateRequest
{
    public string KitapAdi { get; set; } = string.Empty;

    public string? Barkod { get; set; }

    public string? DemirbasNo { get; set; }

    public string? ISBN { get; set; }

    public int? YayinYili { get; set; }

    public int? BaskiYili { get; set; }

    public int? SayfaSayisi { get; set; }

    public int StokAdedi { get; set; }

    public int DurumId { get; set; } = 1;

    public string? Aciklama { get; set; }

    public int? YayineviId { get; set; }

    public int? KategoriId { get; set; }

    public int? OrijinalDilId { get; set; }

    public int? CeviriDilId { get; set; }

    public string? CevirmenAdi { get; set; }

    public bool CeviriMi { get; set; }

    public bool AktifMi { get; set; } = true;

    public List<int> YazarIdleri { get; set; } = new();
}