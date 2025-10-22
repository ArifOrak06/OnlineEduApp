using Microsoft.AspNetCore.Mvc;
using OnlineEduApp.Core.DTOs.MessageDTOs;
using OnlineEduApp.Core.Entities.RequestFeatures;
using OnlineEduApp.Core.Services;
using OnlineEduApp.SharedLibrary.Response;
using OnlineEduApp.SharedLibrary.ResponseResultPattern;
using OnlineEduApp.WebAPI.ActionFilters;
using System.Text.Json;

namespace OnlineEduApp.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessagesController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMessages([FromQuery] MessageParameters messageParameters)
        {
            (CustomResponseDto<List<MessageDto>> responseDto, MetaData metaData) response = await _messageService.GetAllMessagesAsync(messageParameters);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(response.metaData));
            return StatusCode(response.responseDto.StatusCode, response.responseDto.Data);

        }
        [HttpGet]
        public async Task<IActionResult> GetAllDeletedMessages([FromQuery] MessageParameters messageParameters)
        {
            (CustomResponseDto<List<MessageDto>> responseDto, MetaData metaData) response = await _messageService.GetAllDeletedMessagesAsync(messageParameters);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(response.metaData));
            return StatusCode(response.responseDto.StatusCode, response.responseDto.Data);

        }
        [HttpGet("{messageId:int}")]
        public async Task<IActionResult> GetOneMessageById([FromRoute(Name = "messageId")] int messageId)
        {
            CustomResponseDto<MessageDto> response = await _messageService.GetOneMessageByIdAsync(messageId);
            return StatusCode(response.StatusCode, response.Data);
        }
        [HttpGet("{messageId:int}")]
        public async Task<IActionResult> SoftDeleteOneMessage([FromRoute(Name = "messageId")] int messageId)
        {
            CustomResponseDto<NoContentDto> response = await _messageService.SoftDeleteOneMessageAsync(messageId);
            return StatusCode(response.StatusCode);
        }
        [HttpDelete("{messageId:int}")]
        public async Task<IActionResult> DeleteOneMessage([FromRoute(Name = "messageId")] int messageId)
        {
            CustomResponseDto<NoContentDto> response = await _messageService.DeleteOneMessageAsync(messageId);
            return StatusCode(response.StatusCode);
        }
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPost]
        public async Task<IActionResult> CreateOneMessage([FromBody] MessageDtoForCreate messageDtoForCreate)
        {
            CustomResponseDto<MessageDtoForCreate> response = await _messageService.CreateOneMessageAsync(messageDtoForCreate);
            return StatusCode(response.StatusCode, response.Data);
        }
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPut("{messageId:int}")]
        public async Task<IActionResult> UpdateOneMessage([FromRoute(Name = "messageId")] int messageId, [FromBody] MessageDtoForUpdate messageDtoForUpdate)
        {
            CustomResponseDto<MessageDtoForUpdate> response = await _messageService.UpdateOneMessageAsync(messageId, messageDtoForUpdate);
            return StatusCode(response.StatusCode, response.Data);
        }
    }
}
