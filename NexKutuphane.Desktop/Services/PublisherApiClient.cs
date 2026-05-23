using NexKutuphane.Contracts.Common;
using NexKutuphane.Contracts.Publishers;

namespace NexKutuphane.Desktop.Services;

public class PublisherApiClient
{
    private readonly ApiClient _apiClient;

    public PublisherApiClient()
    {
        _apiClient = new ApiClient();
    }

    public async Task<ApiResponse<List<PublisherListResponse>>?> GetAllAsync()
    {
        return await _apiClient.GetAsync<List<PublisherListResponse>>("api/publishers");
    }
}