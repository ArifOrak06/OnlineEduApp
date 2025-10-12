using OnlineEduApp.Core.DTOs.CourseDTOs;
using OnlineEduApp.Core.Entities.RequestFeatures;
using OnlineEduApp.SharedLibrary.Response;
using OnlineEduApp.SharedLibrary.ResponseResultPattern;

namespace OnlineEduApp.Core.Services
{
    public interface ICourseService 
    {
        Task<(CustomResponseDto<List<CourseDto>> responseDto, MetaData metaData)> GetAllCoursesWithCategoryAsync(CourseParameters courseParameters);
        Task<(CustomResponseDto<List<CourseDto>> responseDto, MetaData metaData)> GetAllCoursesByCategoryIdAsync(int categoryId, CourseParameters courseParameters);
        Task<(CustomResponseDto<List<CourseDto>> responseDto, MetaData metaData)> GetAllDeletedCoursesWithCategoryAsync(CourseParameters courseParameters);
        Task<CustomResponseDto<CourseDto>> GetOneCourseByIdAsync(int courseId);
        Task<CustomResponseDto<CourseDtoForCreate>> CreateOneCourseAsync(CourseDtoForCreate courseDtoForCreate);
        Task<CustomResponseDto<CourseDtoForUpdate>> UpdateOneCourseAsync(int courseId, CourseDtoForUpdate courseDtoForUpdate);
        Task<CustomResponseDto<NoContentDto>> DeleteOneCourseAsync(int courseId);
        Task<CustomResponseDto<NoContentDto>> SoftDeleteOneCourseAsync(int courseId);
    


    }
}
