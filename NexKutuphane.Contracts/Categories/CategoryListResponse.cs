namespace NexKutuphane.Contracts.Categories;

public class CategoryListResponse
{
    public int Id { get; set; }

    public string KategoriAdi { get; set; } = string.Empty;

    public string? KategoriKodu { get; set; }

    public string? Aciklama { get; set; }

    public int? UstKategoriId { get; set; }

    public string? UstKategoriAdi { get; set; }

    public bool AktifMi { get; set; }
}