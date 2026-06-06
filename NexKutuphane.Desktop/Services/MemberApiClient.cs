using NexKutuphane.Contracts.Common;
using NexKutuphane.Contracts.Members;

namespace NexKutuphane.Desktop.Services;

public class MemberApiClient
{
    private readonly ApiClient _apiClient;

    public MemberApiClient()
    {
        _apiClient = new ApiClient();
    }

    public async Task<ApiResponse<List<MemberListResponse>>?> GetAllAsync()
    {
        return await _apiClient.GetAsync<List<MemberListResponse>>("api/members");
    }

    public async Task<ApiResponse<MemberDetailResponse>?> GetByIdAsync(int id)
    {
        return await _apiClient.GetAsync<MemberDetailResponse>($"api/members/{id}");
    }

    public async Task<ApiResponse<MemberLookupsResponse>?> GetLookupsAsync()
    {
        return await _apiClient.GetAsync<MemberLookupsResponse>("api/members/lookups");
    }

    public async Task<ApiResponse<MemberDetailResponse>?> CreateAsync(MemberCreateRequest request)
    {
        return await _apiClient.PostAsync<MemberCreateRequest, MemberDetailResponse>("api/members", request);
    }

    public async Task<ApiResponse<MemberDetailResponse>?> UpdateAsync(int id, MemberUpdateRequest request)
    {
        return await _apiClient.PutAsync<MemberUpdateRequest, MemberDetailResponse>($"api/members/{id}", request);
    }

    public async Task<ApiResponse<bool>?> DeleteAsync(int id)
    {
        return await _apiClient.DeleteAsync<bool>($"api/members/{id}");
    }
}