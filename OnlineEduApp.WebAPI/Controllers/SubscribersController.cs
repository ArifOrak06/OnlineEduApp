using Microsoft.AspNetCore.Mvc;
using OnlineEduApp.Core.DTOs.SubscriberDTOs;
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
    public class SubscribersController : ControllerBase
    {
        private readonly ISubscriberService _subscriberService;

        public SubscribersController(ISubscriberService subscriberService)
        {
            _subscriberService = subscriberService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSubscribers([FromQuery] SubscriberParameters subscriberParameters)
        {
            (CustomResponseDto<List<SubscriberDto>> responseDto, MetaData metaData) response = await _subscriberService.GetAllSubscribersAsync(subscriberParameters);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(response.metaData));
            return StatusCode(response.responseDto.StatusCode, response.responseDto.Data);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllDeletedSubscribers([FromQuery] SubscriberParameters subscriberParameters)
        {
            (CustomResponseDto<List<SubscriberDto>> responseDto, MetaData metaData) response = await _subscriberService.GetAllDeletedSubscribersAsync(subscriberParameters);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(response.metaData));
            return StatusCode(response.responseDto.StatusCode, response.responseDto.Data);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllSubscribersNoPagging()
        {
            CustomResponseDto<List<SubscriberDto>> response = await _subscriberService.GetAllSubscribersNoPaggingAsync();
            return StatusCode(response.StatusCode, response.Data);
        }
        [HttpGet("{subscriberId:int}")]
        public async Task<IActionResult> GetOneSubscriberById([FromRoute(Name = "subscriberId")] int subscriberId)
        {
            CustomResponseDto<SubscriberDto> response = await _subscriberService.GetOneSubscriberByIdAsync(subscriberId);
            return StatusCode(response.StatusCode, response.Data);
        }
        [HttpGet("{subscriberId:int}")]
        public async Task<IActionResult> SoftDeleteOneSubscriber([FromRoute(Name = "subscriberId")] int subscriberId)
        {
            CustomResponseDto<NoContentDto> response = await _subscriberService.SoftDeleteOneSubscriberAsync(subscriberId);
            return StatusCode(response.StatusCode);
        }
        [HttpDelete("{subscriberId:int}")]
        public async Task<IActionResult> DeleteOneSubscriber([FromRoute(Name = "subscriberId")] int subscriberId)
        {
            CustomResponseDto<NoContentDto> response = await _subscriberService.DeleteOneSubscriberAsync(subscriberId);
            return StatusCode(response.StatusCode);
        }
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPut("{subscriberId:int}")]
        public async Task<IActionResult> UpdateOneSubscriber([FromRoute(Name = "subscriberId")] int subscriberId, [FromBody] SubscriberDtoForUpdate subscriberDtoForUpdate)
        {
            CustomResponseDto<SubscriberDtoForUpdate> response = await _subscriberService.UpdateOneSubscriberAsync(subscriberId, subscriberDtoForUpdate);
            return StatusCode(response.StatusCode, response.Data);
        }
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPost]
        public async Task<IActionResult> CreateOneSubscriber([FromBody] SubscriberDtoForCreate subscriberDtoForCreate)
        {
            CustomResponseDto<SubscriberDtoForCreate> response = await _subscriberService.CreateOneSubscriberAsync(subscriberDtoForCreate);
            return StatusCode(response.StatusCode, response.Data);
        }

    }
}
