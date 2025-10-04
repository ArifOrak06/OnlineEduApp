using OnlineEduApp.Core.DTOs.AboutDTOs;
using OnlineEduApp.Core.Entities.RequestFeatures;

namespace OnlineEduApp.Core.Services
{
    public interface IAboutService
    {
        Task<(List<AboutDto> aboutDtoList, MetaData metaData)> GetAllActiveAboutsAsync(AboutParameters aboutParameters);
        Task<(List<AboutDto> aboutDtoList, MetaData metaData)> GetAllDeletedAboutsAsync(AboutParameters aboutParameters);
        Task<AboutDto> GetOneAboutByIdAsync(int aboutId);
        Task<AboutDtoForCreate> CreateOneAboutAsync(AboutDtoForCreate aboutDtoForCreate);
        Task<AboutDtoForUpdate> UpdateOneAboutAsync(int aboutId, AboutDtoForUpdate aboutDtoForUpdate);
        Task DeleteOneAboutAsync(int aboutId);
        Task SoftDeleteOneAboutAsync(int aboutId);

    }
}
