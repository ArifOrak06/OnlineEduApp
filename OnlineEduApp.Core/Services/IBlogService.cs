using OnlineEduApp.Core.DTOs.BlogDTOs;
using OnlineEduApp.Core.Entities.RequestFeatures;
using OnlineEduApp.SharedLibrary.Response;
using OnlineEduApp.SharedLibrary.ResponseResultPattern;

namespace OnlineEduApp.Core.Services
{
    public interface IBlogService
    {
        Task<(CustomResponseDto<List<BlogDto>> responseDto, MetaData metaData)> GetAllBlogsWithCategoryAsync(BlogParameters blogParameters);
        Task<(CustomResponseDto<List<BlogDto>> responseDto, MetaData metaData)> GetAllDeletedBlogsWithCategoryAsync(BlogParameters blogParameters);
        Task<(CustomResponseDto<List<BlogDto>> responseDto, MetaData metaData)> GetAllBlogsWithCategoryByCategoryIdAsync(int categoryId, BlogParameters blogParameters);
        Task<CustomResponseDto<BlogDto>> GetOneBlogByIdAsync(int blogId);
        Task<CustomResponseDto<BlogDtoForCreate>> CreateOneBlogAsync(BlogDtoForCreate blogDtoForCreate);
        Task<CustomResponseDto<BlogDtoForUpdate>> UpdateOneBlogAsync(int blogId, BlogDtoForUpdate blogDtoForUpdate);
        Task<CustomResponseDto<NoContentDto>> SoftDeleteOneBlogAsync(int blogId);
        Task<CustomResponseDto<NoContentDto>> DeleteOneBlogAsync(int blogId);
        

    }
}
