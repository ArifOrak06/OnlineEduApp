using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineEduApp.Core.DTOs.CourseDTOs;
using OnlineEduApp.Core.Entities.Concretes;
using OnlineEduApp.Core.Entities.Exceptions;
using OnlineEduApp.Core.Entities.RequestFeatures;
using OnlineEduApp.Core.Repositories;
using OnlineEduApp.Core.Services;
using OnlineEduApp.Core.Utilities.Uow;
using OnlineEduApp.SharedLibrary.Response;
using OnlineEduApp.SharedLibrary.ResponseResultPattern;

namespace OnlineEduApp.Service.Services
{
    public class CourseService : ICourseService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CourseService(IRepositoryManager repositoryManager, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<CourseDtoForCreate>> CreateOneCourseAsync(CourseDtoForCreate courseDtoForCreate)
        {
            if(courseDtoForCreate == null)
                throw new ArgumentNullException(nameof(courseDtoForCreate));
            Course? newCourse = _mapper.Map<Course>(courseDtoForCreate);
            newCourse.CreatedDate = DateTime.UtcNow;
            newCourse.IsActive = true;
            newCourse.IsDeleted = false;
            newCourse.ModifiedDate = DateTime.UtcNow;
            newCourse.CategoryId = courseDtoForCreate.CategoryId;
            await _repositoryManager.CourseRepository.CreateAsync(newCourse);
            await _unitOfWork.CommitAsync();
            return CustomResponseDto<CourseDtoForCreate>.Success(201, _mapper.Map<CourseDtoForCreate>(newCourse));
        }

        public async Task<CustomResponseDto<NoContentDto>> DeleteOneCourseAsync(int courseId)
        {
            Course? currentCourse = await _repositoryManager.CourseRepository.GetByFilter(true,x => x.Id.Equals(courseId)).SingleOrDefaultAsync();
            if(currentCourse == null)
                throw new CourseNotFoundException(courseId);
            _repositoryManager.CourseRepository.Delete(currentCourse);
            await _unitOfWork.CommitAsync();
            return CustomResponseDto<NoContentDto>.Success(204);
        }

        public async Task<(CustomResponseDto<List<CourseDto>> responseDto, MetaData metaData)> GetAllCoursesByCategoryIdAsync(int categoryId, CourseParameters courseParameters)
        {
            PagedList<Course> courses = await _repositoryManager.CourseRepository.GetAllCoursesWithCategoryAsync(false, courseParameters, x => x.CategoryId.Equals(categoryId), x => x.Category);
            if(courses == null)
                throw new ArgumentNullException(nameof(courses));
            List<CourseDto> courseDtos = _mapper.Map<List<CourseDto>>(courses);
            return (CustomResponseDto<List<CourseDto>>.Success(200, courseDtos), courses.MetaData);
        }

        public async Task<(CustomResponseDto<List<CourseDto>> responseDto, MetaData metaData)> GetAllCoursesWithCategoryAsync(CourseParameters courseParameters)
        {
            PagedList<Course> courses = await _repositoryManager.CourseRepository.GetAllCoursesWithCategoryAsync(false, courseParameters, x => x.IsActive && !x.IsDeleted, x => x.Category);
            if(courses == null) 
                throw new ArgumentNullException(nameof(courses));
            List<CourseDto> courseDtoList = _mapper.Map<List<CourseDto>>(courses);
            return (CustomResponseDto<List<CourseDto>>.Success(200,courseDtoList), courses.MetaData);
        }

        public async Task<(CustomResponseDto<List<CourseDto>> responseDto, MetaData metaData)> GetAllDeletedCoursesWithCategoryAsync(CourseParameters courseParameters)
        {
            PagedList<Course> courses = await _repositoryManager.CourseRepository.GetAllCoursesWithCategoryAsync(false, courseParameters, x => !x.IsActive && x.IsDeleted, x => x.Category);
            if (courses == null)
                throw new ArgumentNullException(nameof(courses));
            List<CourseDto> courseDtoList = _mapper.Map<List<CourseDto>>(courses);
            return (CustomResponseDto<List<CourseDto>>.Success(200, courseDtoList), courses.MetaData);
        }

        public async Task<CustomResponseDto<CourseDto>> GetOneCourseByIdAsync(int courseId)
        {
            Course? course = await _repositoryManager.CourseRepository.GetByFilter(false, x => x.Id.Equals(courseId), x => x.Category).SingleOrDefaultAsync();
            if(course == null)
                throw new CourseNotFoundException(courseId);
            return CustomResponseDto<CourseDto>.Success(200, _mapper.Map<CourseDto>(course));
        }

        public async Task<CustomResponseDto<NoContentDto>> SoftDeleteOneCourseAsync(int courseId)
        {
            Course? currentCourse = await _repositoryManager.CourseRepository.GetByFilter(true, x => x.Id.Equals(courseId)).SingleOrDefaultAsync();
            if(currentCourse == null)
                throw new CourseNotFoundException(courseId);
            currentCourse.IsActive = false;
            currentCourse.IsDeleted = true;
            currentCourse.ModifiedDate = DateTime.UtcNow;
            await _unitOfWork.CommitAsync();
            return CustomResponseDto<NoContentDto>.Success(204);
        }

        public async Task<CustomResponseDto<CourseDtoForUpdate>> UpdateOneCourseAsync(int courseId, CourseDtoForUpdate courseDtoForUpdate)
        {
            if(courseDtoForUpdate == null && courseId != courseDtoForUpdate.Id)
                throw new ArgumentNullException(nameof(courseDtoForUpdate));
            Course? currentCourse = await _repositoryManager.CourseRepository.GetByFilter(true,x => x.Id.Equals(courseId)).SingleOrDefaultAsync();
            if(currentCourse == null)
                throw new CourseNotFoundException(courseId);
            currentCourse.IsActive = courseDtoForUpdate.IsActive;
            currentCourse.IsDeleted = courseDtoForUpdate.IsActive ? false : true;
            currentCourse.ModifiedDate = DateTime.UtcNow;
            currentCourse.Name = courseDtoForUpdate.Name;
            currentCourse.ImageUrl = courseDtoForUpdate.ImageUrl;
            currentCourse.Price = courseDtoForUpdate.Price;
            currentCourse.CategoryId = courseDtoForUpdate.CategoryId;
            await _unitOfWork.CommitAsync();
            return CustomResponseDto<CourseDtoForUpdate>.Success(200, _mapper.Map<CourseDtoForUpdate>(currentCourse));
        }
    }
}
