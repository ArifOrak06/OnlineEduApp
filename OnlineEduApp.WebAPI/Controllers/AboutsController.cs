using Microsoft.AspNetCore.Mvc;
using OnlineEduApp.Core.DTOs.AboutDTOs;
using OnlineEduApp.Core.Entities.RequestFeatures;
using OnlineEduApp.Core.Services;
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
            var pagedResult = await _aboutService.GetAllActiveAboutsAsync(aboutParameters);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));
            return Ok(pagedResult.aboutDtoList);
        }
        [HttpGet("getalldeletedabouts")]
        public async Task<IActionResult> GetAllDeletedAbouts([FromQuery]AboutParameters aboutParameters)
        {
            var pagedResult = await _aboutService.GetAllDeletedAboutsAsync(aboutParameters);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));
            return Ok(pagedResult.aboutDtoList);
        }
        [HttpGet("{aboutId:int}")]
        public async Task<IActionResult> GetOneAboutAsync([FromRoute(Name="aboutId")] int aboutId)
        {
            var result = await _aboutService.GetOneAboutByIdAsync(aboutId);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateOneAboutAsync([FromBody] AboutDtoForCreate request)
        {
            var result = await _aboutService.CreateOneAboutAsync(request);
            return Ok(result);
        }
        [HttpGet("{aboutId:int}")]
        public async Task<IActionResult> SoftDeleteOneAboutAsync([FromRoute(Name="aboutId")] int aboutId)
        {
            await _aboutService.SoftDeleteOneAboutAsync(aboutId);
            return NoContent();

        }
        [HttpDelete("{aboutId:int}")]
        public async Task<IActionResult> DeleteOneAboutAsync([FromRoute(Name="aboutId")] int aboutId)
        {
            await _aboutService.DeleteOneAboutAsync(aboutId);
            return NoContent();
        }

    }
}
