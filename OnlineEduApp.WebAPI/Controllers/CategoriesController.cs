using Microsoft.AspNetCore.Mvc;
using OnlineEduApp.Core.DTOs.CategoryDTOs;
using OnlineEduApp.Core.Entities.RequestFeatures;
using OnlineEduApp.Core.Services;
using OnlineEduApp.SharedLibrary.Response;
using OnlineEduApp.SharedLibrary.ResponseResultPattern;
using System.Text.Json;

namespace OnlineEduApp.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategoriesWithBlogsAndCourses([FromQuery]CategoryParameters categoryParameters)
        {
            (CustomResponseDto<List<CategoryDto>> responseDto, MetaData metaData) response = await _categoryService.GetAllCategoriesWithBlogsAndCoursesAsync(categoryParameters);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(response.metaData));
            return StatusCode(response.responseDto.StatusCode, response.responseDto.Data);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllDeletedCategoriesWithBlogsAndCourses([FromQuery] CategoryParameters categoryParameters)
        {
            (CustomResponseDto<List<CategoryDto>> responseDto, MetaData metaData) response = await _categoryService.GetAllDeletedCategoriesWithBlogsAndCoursesAsync(categoryParameters);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(response.metaData));
            return StatusCode(response.responseDto.StatusCode, response.responseDto.Data);
        }
        [HttpGet("{categoryId}")]
        public async Task<IActionResult> GetOneCategoryWithBlogsAndCoursesById(int categoryId)
        {
            CustomResponseDto<CategoryDto> response = await _categoryService.GetOneCategoryWithBlogsAndCoursesByIdAsync(categoryId);
            return StatusCode(response.StatusCode, response.Data);
        }
        [HttpGet("{categoryId:int}")]   
        public async Task<IActionResult> SoftDeleteOneCategory([FromRoute(Name="categoryId")] int categoryId)
        {
            CustomResponseDto<NoContentDto> response = await _categoryService.SoftDeleteOneCategoryAsync(categoryId);
            return StatusCode(response.StatusCode);
        }
        [HttpDelete("{categoryId:int}")]
        public async Task<IActionResult> DeleteOneCategory([FromRoute(Name = "categoryId")] int categoryId)
        {
            CustomResponseDto<NoContentDto> response = await _categoryService.DeleteOneCategoryAsync(categoryId);
            return StatusCode(response.StatusCode);
        }
        [HttpPost]
        public async Task<IActionResult> CreateOneCategory([FromBody]CategoryDtoForCreate request)
        {
            CustomResponseDto<CategoryDtoForCreate> response = await _categoryService.CreateOneCategoryAsync(request);
            return StatusCode(response.StatusCode, response.Data);
        }
        [HttpPut("{categoryId:int}")]
        public async Task<IActionResult> UpdateOneCategory([FromRoute(Name = "categoryId")] int categoryId, [FromBody] CategoryDtoForUpdate request)
        {
            CustomResponseDto<CategoryDtoForUpdate> response = await _categoryService.UpdateOneCategoryAsync(categoryId, request);
            return StatusCode(response.StatusCode, response.Data);
        }

    }
}
