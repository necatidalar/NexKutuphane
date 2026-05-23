using NexKutuphane.Contracts.Categories;
using NexKutuphane.Contracts.Common;

namespace NexKutuphane.Desktop.Services;

public class CategoryApiClient
{
    private readonly ApiClient _apiClient;

    public CategoryApiClient()
    {
        _apiClient = new ApiClient();
    }

    public async Task<ApiResponse<List<CategoryListResponse>>?> GetAllAsync()
    {
        return await _apiClient.GetAsync<List<CategoryListResponse>>("api/categories");
    }
}