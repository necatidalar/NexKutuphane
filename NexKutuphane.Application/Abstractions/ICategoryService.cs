using NexKutuphane.Contracts.Categories;
using NexKutuphane.Contracts.Common;

namespace NexKutuphane.Application.Abstractions;

public interface ICategoryService
{
    Task<ApiResponse<List<CategoryListResponse>>> GetAllAsync();
}