using NexKutuphane.Contracts.Books;
using NexKutuphane.Contracts.Common;

namespace NexKutuphane.Desktop.Services;

public class BookApiClient
{
    private readonly ApiClient _apiClient;

    public BookApiClient()
    {
        _apiClient = new ApiClient();
    }

    public async Task<ApiResponse<List<BookListResponse>>?> GetAllAsync()
    {
        return await _apiClient.GetAsync<List<BookListResponse>>("api/books");
    }

    public async Task<ApiResponse<BookDetailResponse>?> GetByIdAsync(int id)
    {
        return await _apiClient.GetAsync<BookDetailResponse>($"api/books/{id}");
    }

    public async Task<ApiResponse<BookDetailResponse>?> CreateAsync(BookCreateRequest request)
    {
        return await _apiClient.PostAsync<BookCreateRequest, BookDetailResponse>("api/books", request);
    }

    public async Task<ApiResponse<BookDetailResponse>?> UpdateAsync(int id, BookUpdateRequest request)
    {
        return await _apiClient.PutAsync<BookUpdateRequest, BookDetailResponse>($"api/books/{id}", request);
    }

    public async Task<ApiResponse<bool>?> DeleteAsync(int id)
    {
        return await _apiClient.DeleteAsync<bool>($"api/books/{id}");
    }
}