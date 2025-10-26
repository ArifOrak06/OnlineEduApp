using Microsoft.AspNetCore.Mvc;
using OnlineEduApp.Core.DTOs.BlogDTOs;
using OnlineEduApp.Core.Entities.RequestFeatures;
using OnlineEduApp.Core.Services;
using OnlineEduApp.SharedLibrary.ResponseResultPattern;
using OnlineEduApp.WebAPI.ActionFilters;
using System.Text.Json;

namespace OnlineEduApp.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly IBlogService _blogService;

        public BlogsController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBlogsWithCategories([FromQuery] BlogParameters blogParameters)
        {
            (CustomResponseDto<List<BlogDto>> responseDto, MetaData metaData) response = await _blogService.GetAllBlogsWithCategoryAsync(blogParameters);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(response.metaData));
            return StatusCode(response.responseDto.StatusCode, response.responseDto.Data);

        }
        [HttpGet("{categoryId:int}")]
        public async Task<IActionResult> GetAllBlogsByCategoryId([FromRoute(Name = "categoryId")] int categoryId, [FromQuery] BlogParameters blogParameters)
        {
            (CustomResponseDto<List<BlogDto>> responseDto, MetaData metaData) response = await _blogService.GetAllBlogsWithCategoryByCategoryIdAsync(categoryId, blogParameters);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(response.metaData));
            return StatusCode(response.responseDto.StatusCode, response.responseDto.Data);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllDeletedBlogsWithCategories([FromQuery] BlogParameters blogParameters)
        {
            (CustomResponseDto<List<BlogDto>> responseDto, MetaData metaData) response = await _blogService.GetAllDeletedBlogsWithCategoryAsync(blogParameters);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(response.metaData));
            return StatusCode(response.responseDto.StatusCode, response.responseDto.Data);
        }
        [HttpGet("{blogId:int}")]
        public async Task<IActionResult> GetOneBlog([FromRoute(Name = "blogId")] int blogId)
        {
            var response = await _blogService.GetOneBlogByIdAsync(blogId);
            return StatusCode(response.StatusCode, response.Data);
        }
        [HttpGet("{blogId:int}")]
        public async Task<IActionResult> SoftDeleteOneBlog([FromRoute(Name="blogId")] int blogId)
        {
            var response = await _blogService.SoftDeleteOneBlogAsync(blogId);
            return StatusCode(response.StatusCode);
        }
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPost]
        public async Task<IActionResult> CreateOneBlog([FromBody]BlogDtoForCreate blogDtoForCreate)
        {
            
            var response  = await _blogService.CreateOneBlogAsync(blogDtoForCreate);
            return StatusCode(response.StatusCode, response.Data);
        }
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPut("{blogId:int}")]
        public async Task<IActionResult> UpdateOneBlog([FromRoute(Name="blogId")]int blogId, [FromBody] BlogDtoForUpdate blogDtoForUpdate)
        {
           
            var response = await _blogService.UpdateOneBlogAsync(blogId, blogDtoForUpdate);
            return StatusCode(response.StatusCode, response.Data);
        }
        [HttpDelete("{blogId:int}")]
        public async Task<IActionResult> DeleteOneBlog([FromRoute(Name="blogId")]int blogId)
        {
            var response = await _blogService.DeleteOneBlogAsync(blogId);
            return StatusCode(response.StatusCode);
        }
    }
}
