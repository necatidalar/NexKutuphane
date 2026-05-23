namespace NexKutuphane.Contracts.Books;

public class BookDetailResponse
{
    public int Id { get; set; }

    public string KitapAdi { get; set; } = string.Empty;

    public string? Barkod { get; set; }

    public string? DemirbasNo { get; set; }

    public string? ISBN { get; set; }

    public int? YayinYili { get; set; }

    public int? BaskiYili { get; set; }

    public int? SayfaSayisi { get; set; }

    public int StokAdedi { get; set; }

    public int DurumId { get; set; }

    public string Durum { get; set; } = string.Empty;

    public string? Aciklama { get; set; }

    public int? YayineviId { get; set; }

    public string? YayineviAdi { get; set; }

    public int? KategoriId { get; set; }

    public string? KategoriAdi { get; set; }

    public int? OrijinalDilId { get; set; }

    public string? OrijinalDilAdi { get; set; }

    public int? CeviriDilId { get; set; }

    public string? CeviriDilAdi { get; set; }

    public string? CevirmenAdi { get; set; }

    public bool CeviriMi { get; set; }

    public bool AktifMi { get; set; }

    public List<BookAuthorResponse> Yazarlar { get; set; } = new();
}

public class BookAuthorResponse
{
    public int Id { get; set; }

    public string AdSoyad { get; set; } = string.Empty;
}