using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEduApp.Core.DTOs.SocialMediaDTOs;
using OnlineEduApp.Core.Entities.RequestFeatures;
using OnlineEduApp.Core.Services;
using OnlineEduApp.SharedLibrary.Response;
using OnlineEduApp.SharedLibrary.ResponseResultPattern;

namespace OnlineEduApp.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SocialMediasController : ControllerBase
    {
        private readonly ISocialMediaService _socialMediaService;

        public SocialMediasController(ISocialMediaService socialMediaService)
        {
            _socialMediaService = socialMediaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllNoPaggingSocialMedias()
        {
            var result = await _socialMediaService.GetAllSocialMediasNoPaggingAsync();
            return Ok(result.Data);

        }
        [HttpGet]
        public async Task<IActionResult> GetAllSocialMedias([FromQuery]SocialMediaParameters socialMediaParamaters)
        {
            (CustomResponseDto<List<SocialMediaDto>> responseDto, MetaData metaData) response = await _socialMediaService.GetAllSocialMediasAsync(socialMediaParamaters);
            Response.Headers.Add("X-Pagination", System.Text.Json.JsonSerializer.Serialize(response.metaData));
            return StatusCode(response.responseDto.StatusCode, response.metaData);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllDeletedSocialMedias([FromQuery] SocialMediaParameters socialMediaParamaters)
        {
            (CustomResponseDto<List<SocialMediaDto>> responseDto, MetaData metaData) response = await _socialMediaService.GetAllDeletedSocialMediasAsync(socialMediaParamaters);
            Response.Headers.Add("X-Pagination", System.Text.Json.JsonSerializer.Serialize(response.metaData));
            return StatusCode(response.responseDto.StatusCode, response.metaData);
        }
        [HttpGet("{socialMediaId}")]
        public async Task<IActionResult> GetOneSocialMedia([FromRoute(Name="socialMediaId")]int socialMEdiaId)
        {
            CustomResponseDto<SocialMediaDto> result = await _socialMediaService.GetOneSocialMediaAsyncByIdAsync(socialMEdiaId);
            return StatusCode(result.StatusCode, result.Data);
        }
        [HttpGet("{socialMediaId:int}")]
        public async Task<IActionResult> SoftDeleteOneSocialMedia([FromRoute(Name ="socialMediaId")]int socialMediaId)
        {
            CustomResponseDto<NoContentDto> result = await _socialMediaService.SoftDeleteOneSocialMediaAsync(socialMediaId);
            return NoContent();
        }
        [HttpDelete("{socialMediaId:int}")]
        public async Task<IActionResult> DeleteOneSocialMedia([FromRoute(Name="socialMediaId")]int socialMediaId)
        {
            CustomResponseDto<NoContentDto> result = await _socialMediaService.DeleteOneSocialMediaAsync(socialMediaId);    
            return NoContent();
        }
        [HttpPost]
        public async Task<IActionResult> CreateOneSocialMedia([FromBody]SocialMediaDtoForCreate socialMediaDtoForCreate)
        {
            CustomResponseDto<SocialMediaDtoForCreate> result = await _socialMediaService.CreateOneSocialMediaAsync(socialMediaDtoForCreate);
            return StatusCode(result.StatusCode, result.Data);
        }
        [HttpPut("{socialMediaId:int}")]
        public async Task<IActionResult> UpdateOneSocialMediaAsync([FromRoute(Name="socialMediaId")]int socialMediaId,[FromBody]SocialMediaDtoForUpdate socialMediaDtoForUpdate)
        {
            CustomResponseDto<SocialMediaDtoForUpdate> result = await _socialMediaService.UpdateOneSocialMediaAsync(socialMediaId, socialMediaDtoForUpdate);
            return StatusCode(result.StatusCode, result.Data);
        }   
    }
}
