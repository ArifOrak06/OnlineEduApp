using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEduApp.Core.DTOs.TestimonialDTOs;
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
    public class TestimonialsController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;

        public TestimonialsController(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTestimonials([FromQuery]TestimonialParameters testimonialParameters)
        {
            (CustomResponseDto<List<TestimonialDto>> responseDto,MetaData metaData) response = await _testimonialService.GetAllTestimonialsAsync(testimonialParameters);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(response.metaData));
            return StatusCode(response.responseDto.StatusCode, response.responseDto.Data);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllDeletedTestimonials([FromQuery] TestimonialParameters testimonialParameters)
        {
            (CustomResponseDto<List<TestimonialDto>> responseDto, MetaData metaData) response = await _testimonialService.GetAllDeletedTestimonialsAsync(testimonialParameters);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(response.metaData));
            return StatusCode(response.responseDto.StatusCode, response.responseDto.Data);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllNoPaggingTestimonials()
        {
            CustomResponseDto<List<TestimonialDto>> result = await _testimonialService.GetAllTestimonialsNoPaggingAsync();
            return StatusCode(result.StatusCode, result.Data);
        }
        [HttpGet("{testimonialId : int}")]
        public async Task<IActionResult> GetOneTestimonial([FromRoute(Name="testimonialId")] int testimonialId)
        {
            CustomResponseDto<TestimonialDto> result = await _testimonialService.GetOneTestimonialAsync(testimonialId);
            return StatusCode(result.StatusCode, result.Data);
        }
        [HttpGet("{testimonialId:int}")]
        public async Task<IActionResult> SoftDeleteOneTestimonial([FromRoute(Name="testimonialId")] int testimonialId)
        {
            CustomResponseDto<NoContentDto> result = await _testimonialService.SoftDeleteOneTestimonialAsync(testimonialId);
            return StatusCode(result.StatusCode);
        }
        [HttpDelete("{testimonialId:int}")]
        public async Task<IActionResult> DeleteOneTestimonial([FromRoute(Name="testimonialId")]int testimonialId)
        {
            CustomResponseDto<NoContentDto> result = await _testimonialService.DeleteOneTestimonialAsync(testimonialId);
            return StatusCode(result.StatusCode);
        }
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPost]
        public async Task<IActionResult> CreateOneTestimonial([FromBody]TestimonialDtoForCreate testimonialDtoForCreate)
        {
            CustomResponseDto<TestimonialDtoForCreate> result = await _testimonialService.CreateOneTestimonialAsync(testimonialDtoForCreate);
            return StatusCode(result.StatusCode,result.Data);
        }
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPut("{testimonialId : int}")]
        public async Task<IActionResult> UpdateOneTestimonial([FromRoute(Name="testimonialId")]int testimonialId, [FromBody]TestimonialDtoForUpdate testimonialDtoForUpdate)
        {
            CustomResponseDto<TestimonialDtoForUpdate> result = await _testimonialService.UpdateOneTestimonialAsync(testimonialId,testimonialDtoForUpdate);
            return StatusCode(result.StatusCode,result.Data);
        }
    }
}
