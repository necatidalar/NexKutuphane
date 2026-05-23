using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using NexKutuphane.Contracts.Common;
using NexKutuphane.Desktop.Helpers;

namespace NexKutuphane.Desktop.Services;

public class ApiClient
{
    private readonly HttpClient _httpClient;

    private readonly JsonSerializerOptions _jsonOptions = new()
    {
        PropertyNameCaseInsensitive = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };

    public ApiClient()
    {
        _httpClient = new HttpClient
        {
            BaseAddress = new Uri(AppConstants.ApiBaseUrl)
        };
    }

    public async Task<ApiResponse<T>?> GetAsync<T>(string endpoint)
    {
        try
        {
            var response = await _httpClient.GetAsync(endpoint);
            var content = await response.Content.ReadAsStringAsync();

            if (string.IsNullOrWhiteSpace(content))
            {
                return ApiResponse<T>.Fail("API boş cevap döndürdü.");
            }

            var result = JsonSerializer.Deserialize<ApiResponse<T>>(content, _jsonOptions);

            if (result is null)
            {
                return ApiResponse<T>.Fail("API cevabı çözümlenemedi.");
            }

            return result;
        }
        catch (HttpRequestException ex)
        {
            return ApiResponse<T>.Fail($"API bağlantı hatası: {ex.Message}");
        }
        catch (TaskCanceledException)
        {
            return ApiResponse<T>.Fail("API isteği zaman aşımına uğradı.");
        }
        catch (Exception ex)
        {
            return ApiResponse<T>.Fail($"Beklenmeyen hata: {ex.Message}");
        }
    }

    public async Task<ApiResponse<TResponse>?> PostAsync<TRequest, TResponse>(string endpoint, TRequest data)
    {
        try
        {
            var json = JsonSerializer.Serialize(data, _jsonOptions);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(endpoint, content);
            var responseContent = await response.Content.ReadAsStringAsync();

            if (string.IsNullOrWhiteSpace(responseContent))
            {
                return ApiResponse<TResponse>.Fail("API boş cevap döndürdü.");
            }

            var result = JsonSerializer.Deserialize<ApiResponse<TResponse>>(responseContent, _jsonOptions);

            if (result is null)
            {
                return ApiResponse<TResponse>.Fail("API cevabı çözümlenemedi.");
            }

            return result;
        }
        catch (HttpRequestException ex)
        {
            return ApiResponse<TResponse>.Fail($"API bağlantı hatası: {ex.Message}");
        }
        catch (TaskCanceledException)
        {
            return ApiResponse<TResponse>.Fail("API isteği zaman aşımına uğradı.");
        }
        catch (Exception ex)
        {
            return ApiResponse<TResponse>.Fail($"Beklenmeyen hata: {ex.Message}");
        }
    }

    public async Task<ApiResponse<TResponse>?> PutAsync<TRequest, TResponse>(string endpoint, TRequest data)
    {
        try
        {
            var json = JsonSerializer.Serialize(data, _jsonOptions);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync(endpoint, content);
            var responseContent = await response.Content.ReadAsStringAsync();

            if (string.IsNullOrWhiteSpace(responseContent))
            {
                return ApiResponse<TResponse>.Fail("API boş cevap döndürdü.");
            }

            var result = JsonSerializer.Deserialize<ApiResponse<TResponse>>(responseContent, _jsonOptions);

            if (result is null)
            {
                return ApiResponse<TResponse>.Fail("API cevabı çözümlenemedi.");
            }

            return result;
        }
        catch (HttpRequestException ex)
        {
            return ApiResponse<TResponse>.Fail($"API bağlantı hatası: {ex.Message}");
        }
        catch (TaskCanceledException)
        {
            return ApiResponse<TResponse>.Fail("API isteği zaman aşımına uğradı.");
        }
        catch (Exception ex)
        {
            return ApiResponse<TResponse>.Fail($"Beklenmeyen hata: {ex.Message}");
        }
    }

    public async Task<ApiResponse<T>?> DeleteAsync<T>(string endpoint)
    {
        try
        {
            var response = await _httpClient.DeleteAsync(endpoint);
            var content = await response.Content.ReadAsStringAsync();

            if (string.IsNullOrWhiteSpace(content))
            {
                return ApiResponse<T>.Fail("API boş cevap döndürdü.");
            }

            var result = JsonSerializer.Deserialize<ApiResponse<T>>(content, _jsonOptions);

            if (result is null)
            {
                return ApiResponse<T>.Fail("API cevabı çözümlenemedi.");
            }

            return result;
        }
        catch (HttpRequestException ex)
        {
            return ApiResponse<T>.Fail($"API bağlantı hatası: {ex.Message}");
        }
        catch (TaskCanceledException)
        {
            return ApiResponse<T>.Fail("API isteği zaman aşımına uğradı.");
        }
        catch (Exception ex)
        {
            return ApiResponse<T>.Fail($"Beklenmeyen hata: {ex.Message}");
        }
    }
}