namespace NexKutuphane.Contracts.Languages;

public class LanguageListResponse
{
    public int Id { get; set; }

    public string DilAdi { get; set; } = string.Empty;

    public string? DilKodu { get; set; }

    public bool AktifMi { get; set; }
}