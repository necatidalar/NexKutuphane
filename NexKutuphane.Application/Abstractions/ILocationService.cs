using NexKutuphane.Contracts.Common;
using NexKutuphane.Contracts.Locations;

namespace NexKutuphane.Application.Abstractions;

public interface ILocationService
{
    Task<ApiResponse<List<LocationSectionResponse>>> GetSectionsAsync();

    Task<ApiResponse<List<LocationCabinetResponse>>> GetCabinetsAsync(int? sectionId);

    Task<ApiResponse<List<LocationShelfResponse>>> GetShelvesAsync(int? cabinetId);

    Task<ApiResponse<List<BookLocationResponse>>> GetBookLocationsAsync();

    Task<ApiResponse<List<BookLocationResponse>>> GetBookLocationsByBookIdAsync(int bookId);

    Task<ApiResponse<BookLocationResponse>> CreateBookLocationAsync(BookLocationCreateRequest request);

    Task<ApiResponse<BookLocationResponse>> UpdateBookLocationAsync(int id, BookLocationUpdateRequest request);

    Task<ApiResponse<bool>> DeleteBookLocationAsync(int id);
}