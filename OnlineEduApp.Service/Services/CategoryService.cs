using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineEduApp.Core.DTOs.CategoryDTOs;
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
    public class CategoryService : ICategoryService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(IRepositoryManager repositoryManager, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<CategoryDtoForCreate>> CreateOneCategoryAsync(CategoryDtoForCreate categoryDtoForCreate)
        {
            if(categoryDtoForCreate is null)
                throw new ArgumentNullException(nameof(categoryDtoForCreate));
            Category? newCategory = _mapper.Map<Category>(categoryDtoForCreate);
            newCategory.IsActive = true;
            newCategory.IsDeleted = false;
            newCategory.CreatedDate = DateTime.UtcNow;
            newCategory.ModifiedDate = DateTime.UtcNow;
            await _repositoryManager.CategoryRepository.CreateAsync(newCategory);
            await _unitOfWork.CommitAsync();
            return CustomResponseDto<CategoryDtoForCreate>.Success(201, _mapper.Map<CategoryDtoForCreate>(newCategory));
        }

        public async Task<CustomResponseDto<NoContentDto>> DeleteOneCategoryAsync(int categoryId)
        {
            Category? currentCategory = await _repositoryManager.CategoryRepository.GetByFilter(true, x => x.Id.Equals(categoryId)).SingleOrDefaultAsync();
            if (currentCategory is null)
                throw new CategoryNotFoundException(categoryId);
           _repositoryManager.CategoryRepository.Delete(currentCategory);
            await _unitOfWork.CommitAsync();
            return CustomResponseDto<NoContentDto>.Success(204);
        }

        public async Task<(CustomResponseDto<List<CategoryDto>> responseDto, MetaData metaData)> GetAllCategoriesWithBlogsAndCoursesAsync(CategoryParameters categoryParameters)
        {
            PagedList<Category> categories = await _repositoryManager.CategoryRepository.GetAllCategoriesAsync(false,categoryParameters,x => x.IsActive&&!x.IsDeleted, x => x.Blogs, x => x.Courses);
            if(categories is null)
                throw new ArgumentNullException(nameof(categories));
            List<CategoryDto> categoryDtoList = _mapper.Map<List<CategoryDto>>(categories);
            return (CustomResponseDto<List<CategoryDto>>.Success(200, categoryDtoList), categories.MetaData);
        }

        public async  Task<(CustomResponseDto<List<CategoryDto>> responseDto, MetaData metaData)> GetAllDeletedCategoriesWithBlogsAndCoursesAsync(CategoryParameters categoryParameters)
        {
            PagedList<Category> categories = await _repositoryManager.CategoryRepository.GetAllCategoriesAsync(false, categoryParameters, x => !x.IsActive && x.IsDeleted, x => x.Blogs, x => x.Courses);
            if (categories is null)
                throw new ArgumentNullException(nameof(categories));
            List<CategoryDto> categoryDtoList = _mapper.Map<List<CategoryDto>>(categories);
            return (CustomResponseDto<List<CategoryDto>>.Success(200, categoryDtoList), categories.MetaData);
        }

        public async Task<CustomResponseDto<CategoryDto>> GetOneCategoryWithBlogsAndCoursesByIdAsync(int categoryId)
        {
            Category? category = await _repositoryManager.CategoryRepository.GetByFilter(false,x => x.Id.Equals(categoryId), x => x.Blogs, x => x.Courses).SingleOrDefaultAsync();
            if (category is null)
                throw new CategoryNotFoundException(categoryId);
            CategoryDto categoryDto = _mapper.Map<CategoryDto>(category);
            return CustomResponseDto<CategoryDto>.Success(200, categoryDto);
        }

        public async Task<CustomResponseDto<NoContentDto>> SoftDeleteOneCategoryAsync(int categoryId)
        {
            Category? category = await _repositoryManager.CategoryRepository.GetByFilter(true, x => x.Id.Equals(categoryId), x => x.Blogs, x => x.Courses).SingleOrDefaultAsync();
            if (category is null)
                throw new CategoryNotFoundException(categoryId);
            category.IsActive = false;
            category.IsDeleted = true;
            category.ModifiedDate = DateTime.UtcNow;
            await _unitOfWork.CommitAsync();
            return CustomResponseDto<NoContentDto>.Success(204);
        }

        public async Task<CustomResponseDto<CategoryDtoForUpdate>> UpdateOneCategoryAsync(int categoryId, CategoryDtoForUpdate categoryDtoForUpdate)
        {
            if(categoryDtoForUpdate is null && categoryId!=categoryDtoForUpdate.Id)
                throw new ArgumentNullException(nameof(categoryDtoForUpdate));
            Category? category = await _repositoryManager.CategoryRepository.GetByFilter(true, x => x.Id.Equals(categoryId), x => x.Blogs, x => x.Courses).SingleOrDefaultAsync();
            if (category is null)
                throw new CategoryNotFoundException(categoryId);
            category.IsActive = categoryDtoForUpdate.IsActive;
            category.IsDeleted = categoryDtoForUpdate.IsActive ? false : true;
            category.Name = categoryDtoForUpdate.Name;
            category.Icon = categoryDtoForUpdate.Icon;
            category.Description = categoryDtoForUpdate.Description;
            category.ModifiedDate = DateTime.UtcNow;
            await _unitOfWork.CommitAsync();
            return CustomResponseDto<CategoryDtoForUpdate>.Success(200, _mapper.Map<CategoryDtoForUpdate>(category));
        }
    }
}
