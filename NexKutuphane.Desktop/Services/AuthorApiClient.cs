using NexKutuphane.Contracts.Authors;
using NexKutuphane.Contracts.Common;

namespace NexKutuphane.Desktop.Services;

public class AuthorApiClient
{
    private readonly ApiClient _apiClient;

    public AuthorApiClient()
    {
        _apiClient = new ApiClient();
    }

    public async Task<ApiResponse<List<AuthorListResponse>>?> GetAllAsync()
    {
        return await _apiClient.GetAsync<List<AuthorListResponse>>("api/authors");
    }
}