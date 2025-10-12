using Microsoft.AspNetCore.Mvc;
using OnlineEduApp.Core.DTOs.ContactDTOs;
using OnlineEduApp.Core.Services;
using OnlineEduApp.SharedLibrary.Response;
using OnlineEduApp.SharedLibrary.ResponseResultPattern;

namespace OnlineEduApp.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactsController(IContactService contactService)
        {
            _contactService = contactService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllContacts()
        {
            CustomResponseDto<List<ContactDto>> response = await _contactService.GetAllContactsAsync();
            return StatusCode(response.StatusCode, response.Data);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllDeletedContacts()
        {
            CustomResponseDto<List<ContactDto>> response = await _contactService.GetAllDeletedContactsAsync();
            return StatusCode(response.StatusCode, response.Data);
        }
        [HttpGet("{contactId:int}")]
        public async Task<IActionResult> GetOneContactById([FromRoute(Name="contactId")] int contactId)
        {
            CustomResponseDto<ContactDto> response = await _contactService.GetContactByIdAsync(contactId);
            return StatusCode(response.StatusCode, response.Data);
        }
        [HttpGet("{contactId: int}")]
        public async Task<IActionResult> SoftDeleteOneContact([FromRoute(Name= "contactId")] int contactId)
        {
            CustomResponseDto<NoContentDto> response = await _contactService.SoftDeleteOneContactAsync(contactId);
            return StatusCode(response.StatusCode);
        }
        [HttpDelete("{contactId:int}")]
        public async Task<IActionResult> DeleteOneContact([FromRoute(Name="contactId")] int contactId)
        {
            CustomResponseDto<NoContentDto> response = await _contactService.DeleteOneContactAsync(contactId);
            return StatusCode(response.StatusCode);
        }
        [HttpPost]
        public async Task<IActionResult> CreateOneContact([FromBody] ContactDtoForCreate contactDtoForCreate)
        {
            CustomResponseDto<ContactDtoForCreate> response = await _contactService.CreateOneContactAsync(contactDtoForCreate);
            return StatusCode(response.StatusCode, response.Data);
        }
        [HttpPut("{contactId:int}")]
        public async Task<IActionResult> UpdateOneContact([FromRoute(Name="contactId")] int contactId,[FromBody] ContactDtoForUpdate contactDtoForUpdate)
        {
            CustomResponseDto<ContactDtoForUpdate> response = await _contactService.UpdateOneContactAsync(contactId, contactDtoForUpdate);
            return StatusCode(response.StatusCode, response.Data);
        }

    }
}
