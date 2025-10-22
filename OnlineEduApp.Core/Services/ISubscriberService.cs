using OnlineEduApp.Core.DTOs.SubscriberDTOs;
using OnlineEduApp.Core.Entities.RequestFeatures;
using OnlineEduApp.SharedLibrary.Response;
using OnlineEduApp.SharedLibrary.ResponseResultPattern;

namespace OnlineEduApp.Core.Services
{
    public interface ISubscriberService
    {
        Task<(CustomResponseDto<List<SubscriberDto>> responseDto, MetaData metaData)> GetAllSubscribersAsync(SubscriberParameters subscriberParameters);
        Task<(CustomResponseDto<List<SubscriberDto>> responseDto, MetaData metaData)> GetAllDeletedSubscribersAsync(SubscriberParameters subscriberParameters);
        Task<CustomResponseDto<List<SubscriberDto>>> GetAllSubscribersNoPaggingAsync();
        Task<CustomResponseDto<SubscriberDto>> GetOneSubscriberByIdAsync(int subscriberId);
        Task<CustomResponseDto<SubscriberDtoForCreate>> CreateOneSubscriberAsync(SubscriberDtoForCreate subscriberDtoForCreate);
        Task<CustomResponseDto<SubscriberDtoForUpdate>> UpdateOneSubscriberAsync(int subscriberId, SubscriberDtoForUpdate subscriberDtoForUpdate);
        Task<CustomResponseDto<NoContentDto>> DeleteOneSubscriberAsync(int subscriberId);
        Task<CustomResponseDto<NoContentDto>> SoftDeleteOneSubscriberAsync(int subscriberId);
       
    }
}
