using OnlineEduApp.Core.DTOs.BannerDTOs;
using OnlineEduApp.Core.Entities.RequestFeatures;
using OnlineEduApp.SharedLibrary.Response;
using OnlineEduApp.SharedLibrary.ResponseResultPattern;

namespace OnlineEduApp.Core.Services
{
    public interface IBannerService
    {
        Task<(CustomResponseDto<List<BannerDto>> bannerDtoList,MetaData metaData)> GetAllBannersAsync(BannerParameters bannerParameters);
        Task<(CustomResponseDto<List<BannerDto>> bannerListDto, MetaData metaData)> GetAllDeletedBannersAsync(BannerParameters bannerParameters);
        Task<CustomResponseDto<BannerDto>> GetBannerDtoByIdAsync(int bannerId);
        Task<CustomResponseDto<BannerDtoForCreate>> CreateOneBannerAsync(int bannerId, BannerDtoForCreate bannerDtoForCreate);
        Task<CustomResponseDto<NoContentDto>> DeleteOneBannerAsync(int bannerId);
        Task<CustomResponseDto<NoContentDto>> SoftDeleteOneBannerAsync(int bannerId);
        Task<CustomResponseDto<BannerDtoForUpdate>> UpdateOneBannerAsync(int bannerId, BannerDtoForUpdate bannerDtoForUpdate);

    }
}
