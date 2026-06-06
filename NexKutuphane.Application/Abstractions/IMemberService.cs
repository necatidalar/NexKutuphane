using NexKutuphane.Contracts.Common;
using NexKutuphane.Contracts.Members;

namespace NexKutuphane.Application.Abstractions;

public interface IMemberService
{
    Task<ApiResponse<List<MemberListResponse>>> GetAllAsync();

    Task<ApiResponse<MemberDetailResponse>> GetByIdAsync(int id);

    Task<ApiResponse<MemberDetailResponse>> CreateAsync(MemberCreateRequest request);

    Task<ApiResponse<MemberDetailResponse>> UpdateAsync(int id, MemberUpdateRequest request);

    Task<ApiResponse<bool>> DeleteAsync(int id);

    Task<ApiResponse<MemberLookupsResponse>> GetLookupsAsync();
}