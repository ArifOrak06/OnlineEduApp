using Microsoft.AspNetCore.Mvc;
using OnlineEduApp.Core.DTOs.BannerDTOs;
using OnlineEduApp.Core.Entities.RequestFeatures;
using OnlineEduApp.Core.Services;
using OnlineEduApp.SharedLibrary.ResponseResultPattern;
using System.Text.Json;

namespace OnlineEduApp.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BannersController : ControllerBase
    {
        private readonly IBannerService _bannerService;

        public BannersController(IBannerService bannerService)
        {
            _bannerService = bannerService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllBannersAsync([FromQuery] BannerParameters bannerParameters)
        {
            (CustomResponseDto<List<BannerDto>>? responseDto, MetaData? metaData) pagedResult = await _bannerService.GetAllBannersAsync(bannerParameters);
            if (pagedResult.responseDto.StatusCode == 200)
            {
                Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));
                return Ok(pagedResult.responseDto.Data);
            }
            return BadRequest();
        }
        [HttpGet]
        public async Task<IActionResult> GetAllDeletedBannersAsync([FromQuery] BannerParameters bannerParameters)
        {
            (CustomResponseDto<List<BannerDto>>? responseDto, MetaData? metaData) pagedResult = await _bannerService.GetAllDeletedBannersAsync(bannerParameters);
            if (pagedResult.responseDto?.StatusCode == 200)
            {
                Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));
                return Ok(pagedResult.responseDto.Data);
            }
            return BadRequest();


        }
        [HttpGet("{bannerId:int}")]
        public async Task<IActionResult> GetOneBannerAsync([FromRoute(Name = "bannerId")] int bannerId)
        {
            var result = await _bannerService.GetBannerDtoByIdAsync(bannerId);
            if (result.StatusCode == 200)
                return Ok(result.Data);
            return BadRequest();
        }
        [HttpGet("{bannerId:int}")]
        public async Task<IActionResult> SoftDeleteOneBannerAsync([FromRoute(Name = "bannerId")] int bannerId)
        {
            var result = await _bannerService.SoftDeleteOneBannerAsync(bannerId);
            if (result.StatusCode == 204)
                return NoContent();
            return BadRequest();
        }
        [HttpDelete("{bannerId:int}")]
        public async Task<IActionResult> DeleteOneBannerAsync([FromRoute(Name = "bannerId")] int bannerId)
        {
            var result = await _bannerService.DeleteOneBannerAsync(bannerId);
            if (result.StatusCode == 204)
                return NoContent();
            return BadRequest();
        }
        [HttpPost]
        public async Task<IActionResult> CreateOneBannerAsync([FromBody]BannerDtoForCreate request)
        {
            var result = await _bannerService.CreateOneBannerAsync(request);
            if(result.StatusCode == 200)
                return Ok(result.Data);
            return BadRequest();
        }
        [HttpPut("{bannerId:int}")]
        public async Task<IActionResult> UpdateOneBannerAsync([FromRoute(Name="bannerId")] int bannerId, [FromBody]BannerDtoForUpdate request)
        {
            var result = await _bannerService.UpdateOneBannerAsync(bannerId, request);
            if(result.StatusCode == 200)
                return Ok(result.Data);
            return BadRequest();
        }
    }
}
