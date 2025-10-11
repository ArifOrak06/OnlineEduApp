using Microsoft.AspNetCore.Mvc;
using OnlineEduApp.Core.DTOs.ContactDTOs;
using OnlineEduApp.Core.Services;
using OnlineEduApp.SharedLibrary.ResponseResultPattern;

namespace OnlineEduApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
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
    }
}
