using NexKutuphane.Contracts.Common;
using NexKutuphane.Contracts.Languages;

namespace NexKutuphane.Application.Abstractions;

public interface ILanguageService
{
    Task<ApiResponse<List<LanguageListResponse>>> GetAllAsync();
}