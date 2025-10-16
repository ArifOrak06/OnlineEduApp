using OnlineEduApp.Core.DTOs.SocialMediaDTOs;
using OnlineEduApp.Core.Entities.RequestFeatures;
using OnlineEduApp.SharedLibrary.Response;
using OnlineEduApp.SharedLibrary.ResponseResultPattern;

namespace OnlineEduApp.Core.Services
{
    public interface ISocialMediaService
    {
        Task<(CustomResponseDto<List<SocialMediaDto>> responseDto, MetaData metaData)> GetAllSocialMediasAsync(SocialMediaParameters socialMediaParameters);
        Task<(CustomResponseDto<List<SocialMediaDto>> responseDto, MetaData metaData)> GetAllDeletedSocialMediasAsync(SocialMediaParameters socialMediaParameters);
        Task<CustomResponseDto<List<SocialMediaDto>>> GetAllSocialMediasNoPaggingAsync();
        Task<CustomResponseDto<SocialMediaDto>> GetOneSocialMediaAsyncByIdAsync(int socialMediaId);
        Task<CustomResponseDto<SocialMediaDtoForCreate>> CreateOneSocialMediaAsync(SocialMediaDtoForCreate socialMediaDtoForCreate);
        Task<CustomResponseDto<SocialMediaDtoForUpdate>> UpdateOneSocialMediaAsync(int socialMediaId,SocialMediaDtoForUpdate socialMediaDtoForUpdate);
        Task<CustomResponseDto<NoContentDto>> SoftDeleteOneSocialMediaAsync(int socialMediaId);
        Task<CustomResponseDto<NoContentDto>> DeleteOneSocialMediaAsync(int socialMediaId);
    }
}
