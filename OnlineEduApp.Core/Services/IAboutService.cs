using OnlineEduApp.Core.DTOs.AboutDTOs;
using OnlineEduApp.Core.Entities.RequestFeatures;
using OnlineEduApp.SharedLibrary.Response;
using OnlineEduApp.SharedLibrary.ResponseResultPattern;

namespace OnlineEduApp.Core.Services
{
    public interface IAboutService
    {
        Task<(CustomResponseDto<List<AboutDto>> responseDtoList, MetaData metaData)> GetAllActiveAboutsAsync(AboutParameters aboutParameters);
        Task<(CustomResponseDto<List<AboutDto>> responseDtoList, MetaData metaData)> GetAllDeletedAboutsAsync(AboutParameters aboutParameters);
        Task<CustomResponseDto<AboutDto>> GetOneAboutByIdAsync(int aboutId);
        Task<CustomResponseDto<AboutDtoForCreate>> CreateOneAboutAsync(AboutDtoForCreate aboutDtoForCreate);
        Task<CustomResponseDto<AboutDtoForUpdate>> UpdateOneAboutAsync(int aboutId, AboutDtoForUpdate aboutDtoForUpdate);
        Task<CustomResponseDto<NoContentDto>> DeleteOneAboutAsync(int aboutId);
        Task<CustomResponseDto<NoContentDto>> SoftDeleteOneAboutAsync(int aboutId);

    }
}
