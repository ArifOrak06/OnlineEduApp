using OnlineEduApp.Core.DTOs.ContactDTOs;
using OnlineEduApp.SharedLibrary.Response;
using OnlineEduApp.SharedLibrary.ResponseResultPattern;

namespace OnlineEduApp.Core.Services
{
    public interface IContactService
    {
        Task<CustomResponseDto<List<ContactDto>>> GetAllContactsAsync();
        Task<CustomResponseDto<List<ContactDto>>> GetAllDeletedContactsAsync();
        Task<CustomResponseDto<ContactDto>> GetContactByIdAsync(int contactId);
        Task<CustomResponseDto<ContactDtoForCreate>> CreateOneContactAsync(ContactDtoForCreate contactDtoForCreate);
        Task<CustomResponseDto<ContactDtoForUpdate>> UpdateOneContactAsync(int contactId,ContactDtoForUpdate contactDtoForUpdate);
        Task<CustomResponseDto<NoContentDto>> DeleteOneContactAsync(int contactId);
        Task<CustomResponseDto<NoContentDto>> SoftDeleteOneContactAsync(int contactId);


    }
}
