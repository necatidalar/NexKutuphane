namespace NexKutuphane.Contracts.Members;

public class MemberLookupsResponse
{
    public List<MemberLookupItemResponse> UyeTurleri { get; set; } = new();

    public List<MemberLookupItemResponse> Siniflar { get; set; } = new();

    public List<MemberLookupItemResponse> Subeler { get; set; } = new();

    public List<MemberLookupItemResponse> Bolumler { get; set; } = new();

    public List<MemberLookupItemResponse> Alanlar { get; set; } = new();

    public List<MemberLookupItemResponse> Durumlar { get; set; } = new();
}

public class MemberLookupItemResponse
{
    public int Id { get; set; }

    public string Ad { get; set; } = string.Empty;

    public int? ParentId { get; set; }
}