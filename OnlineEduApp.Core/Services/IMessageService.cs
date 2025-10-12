using OnlineEduApp.Core.DTOs.MessageDTOs;
using OnlineEduApp.Core.Entities.RequestFeatures;
using OnlineEduApp.SharedLibrary.Response;
using OnlineEduApp.SharedLibrary.ResponseResultPattern;

namespace OnlineEduApp.Core.Services
{
    public interface IMessageService
    {
        Task<(CustomResponseDto<List<MessageDto>> responseDto, MetaData metaData)> GetAllMessagesAsync(MessageParameters messageParameters);
        Task<(CustomResponseDto<List<MessageDto>> responseDto, MetaData metaData)> GetAllDeletedMessagesAsync(MessageParameters messageParameters);
        Task<CustomResponseDto<List<MessageDto>>> GetAllNoPagingMessagesAsync();
        Task<CustomResponseDto<MessageDto>> GetOneMessageByIdAsync(int messageId);
        Task<CustomResponseDto<MessageDtoForCreate>> CreateOneMessageAsync(MessageDtoForCreate messageDtoForCreate);
        Task<CustomResponseDto<MessageDtoForUpdate>> UpdateOneMessageAsync(int messageId, MessageDtoForUpdate messageDtoForUpdate);
        Task<CustomResponseDto<NoContentDto>> DeleteOneMessageAsync(int messageId);
        Task<CustomResponseDto<NoContentDto>> SoftDeleteOneMessageAsync(int messageId);
    }
}
