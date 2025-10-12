using Microsoft.AspNetCore.Mvc;
using OnlineEduApp.Core.DTOs.CourseDTOs;
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
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCoursesAndCategory([FromQuery]CourseParameters courseParameters)
        {
            (CustomResponseDto<List<CourseDto>> responseDto, MetaData metaData) response = await _courseService.GetAllCoursesWithCategoryAsync(courseParameters);
            Response.Headers.Add("X-Pagination",JsonSerializer.Serialize(response.metaData));
            return StatusCode(response.responseDto.StatusCode, response.responseDto.Data);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllDeletedCoursesAndCategory([FromQuery] CourseParameters courseParameters)
        {
            (CustomResponseDto<List<CourseDto>> responseDto, MetaData metaData) response = await _courseService.GetAllDeletedCoursesWithCategoryAsync(courseParameters);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(response.metaData));
            return StatusCode(response.responseDto.StatusCode, response.responseDto.Data);
        }
        [HttpGet("{categoryId:int}")]
        public async Task<IActionResult> GetAllCoursesByCategoryId([FromRoute(Name = "categoryId")]int categoryId, [FromQuery]CourseParameters courseParameters)
        {
            (CustomResponseDto<List<CourseDto>> responseDto, MetaData metaData) response = await _courseService.GetAllCoursesByCategoryIdAsync(categoryId, courseParameters);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(response.metaData));
            return StatusCode(response.responseDto.StatusCode, response.responseDto.Data);
        }
        [HttpGet("{courseId:int}")]
        public async Task<IActionResult> GetOneCourseById([FromRoute(Name = "courseId")] int courseId)
        {
            CustomResponseDto<CourseDto> response = await _courseService.GetOneCourseByIdAsync(courseId);
            return StatusCode(response.StatusCode, response.Data);
        }
        [HttpGet("{courseId:int}")]
        public async Task<IActionResult> SoftDeleteOneCourse([FromRoute(Name = "courseId")]int courseId)
        {
            CustomResponseDto<NoContentDto> response = await _courseService.SoftDeleteOneCourseAsync(courseId);
            return StatusCode(response.StatusCode);
        }
        [HttpDelete("{courseId:int}")]
        public async Task<IActionResult> DeleteOneCourse([FromRoute(Name = "courseId")]int courseId)
        {
            CustomResponseDto<NoContentDto> response = await _courseService.DeleteOneCourseAsync(courseId);
            return StatusCode(response.StatusCode);
        }
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPost]
        public async Task<IActionResult> CreateOneCourse([FromBody] CourseDtoForCreate courseDtoForCreate)
        {
            CustomResponseDto<CourseDtoForCreate> response = await _courseService.CreateOneCourseAsync(courseDtoForCreate);
            return StatusCode(response.StatusCode, response.Data);
        }
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPut("{courseId:int}")]
        public async Task<IActionResult> UpdateOneCourse([FromRoute(Name = "courseId")] int courseId, [FromBody] CourseDtoForUpdate courseDtoForUpdate)
        {
            CustomResponseDto<CourseDtoForUpdate> response = await _courseService.UpdateOneCourseAsync(courseId, courseDtoForUpdate);
            return StatusCode(response.StatusCode, response.Data);
        }
    }
}
