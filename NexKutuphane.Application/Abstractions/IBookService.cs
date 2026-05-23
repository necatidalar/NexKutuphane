using NexKutuphane.Contracts.Books;
using NexKutuphane.Contracts.Common;

namespace NexKutuphane.Application.Abstractions;

public interface IBookService
{
    Task<ApiResponse<List<BookListResponse>>> GetAllAsync();

    Task<ApiResponse<BookDetailResponse>> GetByIdAsync(int id);

    Task<ApiResponse<BookDetailResponse>> CreateAsync(BookCreateRequest request);

    Task<ApiResponse<BookDetailResponse>> UpdateAsync(int id, BookUpdateRequest request);

    Task<ApiResponse<bool>> DeleteAsync(int id);
}