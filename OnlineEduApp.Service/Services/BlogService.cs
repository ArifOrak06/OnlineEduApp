using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineEduApp.Core.DTOs.BlogDTOs;
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
    public class BlogService : IBlogService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public BlogService(IRepositoryManager repositoryManager, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<CustomResponseDto<BlogDtoForCreate>> CreateOneBlogAsync(BlogDtoForCreate blogDtoForCreate)
        {
            if(blogDtoForCreate == null)
                throw new ArgumentNullException(nameof(blogDtoForCreate));
            Blog? newBlog = _mapper.Map<Blog>(blogDtoForCreate);
            newBlog.CreatedDate = DateTime.UtcNow;
            newBlog.IsActive = true;
            newBlog.IsDeleted = false;
            newBlog.CategoryId = blogDtoForCreate.CategoryId; 
            await _repositoryManager.BlogRepository.CreateAsync(newBlog);
            await _unitOfWork.CommitAsync();
            return CustomResponseDto<BlogDtoForCreate>.Success(200,_mapper.Map<BlogDtoForCreate>(newBlog));
        }

        public async Task<CustomResponseDto<NoContentDto>> DeleteOneBlogAsync(int blogId)
        {
            Blog? currentBlog = await _repositoryManager.BlogRepository.GetByFilter(true,x => x.Id.Equals(blogId)).SingleOrDefaultAsync();
            if(currentBlog == null)
                throw new BlogNotFoundException(blogId);
            _repositoryManager.BlogRepository.Delete(currentBlog);
            await _unitOfWork.CommitAsync();
            return CustomResponseDto<NoContentDto>.Success(204);
        }

        public async Task<(CustomResponseDto<List<BlogDto>> responseDto, MetaData metaData)> GetAllBlogsWithCategoryAsync(BlogParameters blogParameters)
        {
            if(!blogParameters.ValidPriceRange)
                throw new PriceOutOfRangeBadRequestException(); // Global hata yakalama da hata yakalanacak ve Status Code 400 olarak döndürülecek.

            PagedList<Blog> items = await _repositoryManager.BlogRepository.GetAllBlogsAsync(false,blogParameters, x=> x.IsActive&&!x.IsDeleted,x => x.Category);
            if(items is null)
                throw new ArgumentNullException(nameof(items));
            List<BlogDto> blogDtos = _mapper.Map<List<BlogDto>>(items);
            return (CustomResponseDto<List<BlogDto>>.Success(200, blogDtos), items.MetaData);
        }

        public async Task<(CustomResponseDto<List<BlogDto>> responseDto, MetaData metaData)> GetAllDeletedBlogsWithCategoryAsync(BlogParameters blogParameters)
        {
            PagedList<Blog> items = await _repositoryManager.BlogRepository.GetAllBlogsAsync(false, blogParameters, x => !x.IsActive && x.IsDeleted, x => x.Category);
            if (items is null)
                throw new ArgumentNullException(nameof(items));
            List<BlogDto> blogDtos = _mapper.Map<List<BlogDto>>(items);
            return (CustomResponseDto<List<BlogDto>>.Success(200, blogDtos), items.MetaData);
        }

        public async Task<CustomResponseDto<BlogDto>> GetOneBlogByIdAsync(int blogId)
        {
            Blog? currentBlog = await _repositoryManager.BlogRepository.GetByFilter(false,x => x.Id.Equals(blogId),x => x.Category).SingleOrDefaultAsync();
            if(currentBlog == null)
                throw new BlogNotFoundException(blogId);
            return CustomResponseDto<BlogDto>.Success(200,_mapper.Map<BlogDto>(currentBlog));
        }

        public async Task<CustomResponseDto<NoContentDto>> SoftDeleteOneBlogAsync(int blogId)
        {
            Blog? currentBlog =  _repositoryManager.BlogRepository.GetByFilter(true,x => x.Id.Equals(blogId)).SingleOrDefault();
            if(currentBlog == null)
                throw new BlogNotFoundException(blogId);
            currentBlog.IsActive = false;
            currentBlog.IsDeleted = true;
            await _unitOfWork.CommitAsync();
            return CustomResponseDto<NoContentDto>.Success(204);
        }

        public async Task<CustomResponseDto<BlogDtoForUpdate>> UpdateOneBlogAsync(int blogId, BlogDtoForUpdate blogDtoForUpdate)
        {
            if(blogDtoForUpdate == null && blogId != blogDtoForUpdate.Id)
                throw new ArgumentNullException(nameof(blogDtoForUpdate));
            Blog? currentBlog = await _repositoryManager.BlogRepository.GetByFilter(true,x => x.Id.Equals(blogId)).SingleOrDefaultAsync();
            if(currentBlog == null)
                throw new BlogNotFoundException(blogId);
            currentBlog.IsActive = blogDtoForUpdate.IsActive;
            currentBlog.IsDeleted = blogDtoForUpdate.IsActive ? false : true;
            currentBlog.Title = blogDtoForUpdate.Title;
            currentBlog.Content = blogDtoForUpdate.Content;
            currentBlog.ImageUrl = blogDtoForUpdate.ImageUrl;
            currentBlog.CategoryId = blogDtoForUpdate.CategoryId;
            currentBlog.ModifiedDate = DateTime.UtcNow;
            await _unitOfWork.CommitAsync();
            return CustomResponseDto<BlogDtoForUpdate>.Success(200,_mapper.Map<BlogDtoForUpdate>(currentBlog));
        }
    }
}
