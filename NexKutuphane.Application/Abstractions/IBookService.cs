using NexKutuphane.Contracts.Books;
using NexKutuphane.Contracts.Common;

namespace NexKutuphane.Application.Abstractions;

public interface IBookService
{
    Task<ApiResponse<List<BookListResponse>>> GetAllAsync();
}