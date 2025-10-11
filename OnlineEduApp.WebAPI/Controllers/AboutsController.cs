using Microsoft.AspNetCore.Mvc;
using OnlineEduApp.Core.DTOs.AboutDTOs;
using OnlineEduApp.Core.Entities.RequestFeatures;
using OnlineEduApp.Core.Services;
using OnlineEduApp.SharedLibrary.Response;
using OnlineEduApp.SharedLibrary.ResponseResultPattern;
using System.Text.Json;

namespace OnlineEduApp.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AboutsController : ControllerBase
    {
        private readonly IAboutService _aboutService;

        public AboutsController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAbouts([FromQuery]AboutParameters aboutParameters)
        {
            // değişken tipini tanımlarken Service katmanından gelecek olan tuple'ın içeriğine göre tanımladık ki karışıklık olmasın ve MetaData'yı veyahut asıl data'yı kullanmak için erişebilelim.

            (CustomResponseDto<List<AboutDto>>? responseDtoList,MetaData? metaData) pagedResult = await _aboutService.GetAllActiveAboutsAsync(aboutParameters);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));


            return Ok(pagedResult.responseDtoList.Data); 
            
            // aboutDtoList = CustomResponseDto<List<AboutDto> demektir, Service katmanından sunum katmanına responseDtoList adı ile gönderilmiştir. 
        }
        [HttpGet("getalldeletedabouts")]
        public async Task<IActionResult> GetAllDeletedAbouts([FromQuery]AboutParameters aboutParameters)
        {
            var pagedResult = await _aboutService.GetAllDeletedAboutsAsync(aboutParameters);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));
            return Ok(pagedResult.responseDtoList.Data);
        }
        [HttpGet("{aboutId:int}")]
        public async Task<IActionResult> GetOneAboutAsync([FromRoute(Name="aboutId")] int aboutId)
        {
            CustomResponseDto<AboutDto>? result = await _aboutService.GetOneAboutByIdAsync(aboutId);
            return Ok(result.Data);
        }
        [HttpPost]
        public async Task<IActionResult> CreateOneAboutAsync([FromBody] AboutDtoForCreate request)
        {
            CustomResponseDto<AboutDtoForCreate>? result = await _aboutService.CreateOneAboutAsync(request);
            return Ok(result.Data);
        }
        [HttpGet("{aboutId:int}")]
        public async Task<IActionResult> SoftDeleteOneAboutAsync([FromRoute(Name="aboutId")] int aboutId)
        {
            CustomResponseDto<NoContentDto>? result = await _aboutService.SoftDeleteOneAboutAsync(aboutId);
            if(result.StatusCode == 204)
                return NoContent();
            return BadRequest();

        }
        [HttpDelete("{aboutId:int}")]
        public async Task<IActionResult> DeleteOneAboutAsync([FromRoute(Name="aboutId")] int aboutId)
        {
            CustomResponseDto<NoContentDto>? result = await _aboutService.DeleteOneAboutAsync(aboutId);
            if (result.StatusCode == 204)
                return NoContent();
            return BadRequest();
        }
        [HttpPut("{aboutId:int}")]
        public async Task<IActionResult> UpdateOneAboutAsync([FromRoute(Name="aboutId")] int aboutId, [FromBody]AboutDtoForUpdate request)
        {
            var result = await _aboutService.UpdateOneAboutAsync(aboutId, request);
            if(result.StatusCode == 200)
                return Ok(result.Data);
            return BadRequest();
        }

    }
}
