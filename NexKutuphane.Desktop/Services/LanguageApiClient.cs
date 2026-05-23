using NexKutuphane.Contracts.Common;
using NexKutuphane.Contracts.Languages;

namespace NexKutuphane.Desktop.Services;

public class LanguageApiClient
{
    private readonly ApiClient _apiClient;

    public LanguageApiClient()
    {
        _apiClient = new ApiClient();
    }

    public async Task<ApiResponse<List<LanguageListResponse>>?> GetAllAsync()
    {
        return await _apiClient.GetAsync<List<LanguageListResponse>>("api/languages");
    }
}