using NexKutuphane.Contracts.Authors;
using NexKutuphane.Contracts.Common;

namespace NexKutuphane.Application.Abstractions;

public interface IAuthorService
{
    Task<ApiResponse<List<AuthorListResponse>>> GetAllAsync();
}