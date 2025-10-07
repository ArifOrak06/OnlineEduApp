using OnlineEduApp.Core.DTOs.CategoryDTOs;
using OnlineEduApp.Core.Entities.RequestFeatures;
using OnlineEduApp.SharedLibrary.Response;
using OnlineEduApp.SharedLibrary.ResponseResultPattern;

namespace OnlineEduApp.Core.Services
{
    public interface ICategoryService
    {
        Task<(CustomResponseDto<List<CategoryDto>> responseDto, MetaData metaData)> GetAllCategoriesWithBlogsAndCoursesAsync(CategoryParameters categoryParameters);
        Task<(CustomResponseDto<List<CategoryDto>> responseDto, MetaData metaData)> GetAllDeletedCategoriesWithBlogsAndCoursesAsync(CategoryParameters categoryParameters);
        Task<CustomResponseDto<CategoryDto>> GetOneCategoryWithBlogsAndCoursesByIdAsync(int categoryId);
        Task<CustomResponseDto<CategoryDtoForCreate>> CreateOneCategoryAsync(CategoryDtoForCreate categoryDtoForCreate);
        Task<CustomResponseDto<CategoryDtoForUpdate>> UpdateOneCategoryAsync(int categoryId, CategoryDtoForUpdate categoryDtoForUpdate);
        Task<CustomResponseDto<NoContentDto>> DeleteOneCategoryAsync(int categoryId);
        Task<CustomResponseDto<NoContentDto>> SoftDeleteOneCategoryAsync(int categoryId);

    }
}
