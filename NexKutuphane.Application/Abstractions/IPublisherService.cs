using NexKutuphane.Contracts.Common;
using NexKutuphane.Contracts.Publishers;

namespace NexKutuphane.Application.Abstractions;

public interface IPublisherService
{
    Task<ApiResponse<List<PublisherListResponse>>> GetAllAsync();
}