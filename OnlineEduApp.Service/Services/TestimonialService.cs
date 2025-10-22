using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineEduApp.Core.DTOs.TestimonialDTOs;
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
    public class TestimonialService : ITestimonialService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TestimonialService(IRepositoryManager repositoryManager, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<TestimonialDtoForCreate>> CreateOneTestimonialAsync(TestimonialDtoForCreate testimonialDtoForCreate)
        {
            if (testimonialDtoForCreate == null)
                throw new ArgumentNullBadRequestException();
            Testimonial? newTestimonial = _mapper.Map<Testimonial>(testimonialDtoForCreate);
            newTestimonial.CreatedDate = DateTime.UtcNow;
            newTestimonial.IsActive = true;
            newTestimonial.IsDeleted = false;
            newTestimonial.ModifiedDate = DateTime.UtcNow;
            await _repositoryManager.TestimonialRepository.CreateAsync(newTestimonial);
            await _unitOfWork.CommitAsync();
            return CustomResponseDto<TestimonialDtoForCreate>.Success(200, _mapper.Map<TestimonialDtoForCreate>(newTestimonial));

        }

        public async Task<CustomResponseDto<NoContentDto>> DeleteOneTestimonialAsync(int testimonialId)
        {
            Testimonial? currentEntity = await CheckEntityAsync(true,testimonialId);
            _repositoryManager.TestimonialRepository.Delete(currentEntity);
            await _unitOfWork.CommitAsync();
            return CustomResponseDto<NoContentDto>.Success(204);
        }

        public async Task<(CustomResponseDto<List<TestimonialDto>> responseDto, MetaData metaData)> GetAllDeletedTestimonialsAsync(TestimonialParameters testimonialParameters)
        {
            PagedList<Testimonial>? testimonialsAndMetaData = await _repositoryManager.TestimonialRepository.GetAllTestimonialsAsync(false, x => !x.IsActive && x.IsDeleted, testimonialParameters);
            if (testimonialsAndMetaData == null)
                throw new ArgumentNullException(nameof(testimonialsAndMetaData));
            List<TestimonialDto>? testimonialDtos = _mapper.Map<List<TestimonialDto>>(testimonialsAndMetaData);
            return (CustomResponseDto<List<TestimonialDto>>.Success(200, testimonialDtos), testimonialsAndMetaData.MetaData);
        }

        public async Task<(CustomResponseDto<List<TestimonialDto>> responseDto, MetaData metaData)> GetAllTestimonialsAsync(TestimonialParameters testimonialParameters)
        {
            PagedList<Testimonial>? testimonialsAndMetaData = await _repositoryManager.TestimonialRepository.GetAllTestimonialsAsync(false, x => x.IsActive && !x.IsDeleted, testimonialParameters);
            if(testimonialsAndMetaData == null)
                throw new ArgumentNullException(nameof(testimonialsAndMetaData));
            List<TestimonialDto>? testimonialDtos = _mapper.Map<List<TestimonialDto>>(testimonialsAndMetaData);
            return (CustomResponseDto<List<TestimonialDto>>.Success(200, testimonialDtos), testimonialsAndMetaData.MetaData);
        }

        public async Task<CustomResponseDto<List<TestimonialDto>>> GetAllTestimonialsNoPaggingAsync()
        {
            List<Testimonial>? testimonials = await _repositoryManager.TestimonialRepository.GetByFilter(false,x => x.IsActive&&!x.IsDeleted).ToListAsync();
            if(testimonials == null)
                throw new ArgumentNullException(nameof(testimonials));
            return CustomResponseDto<List<TestimonialDto>>.Success(200, _mapper.Map<List<TestimonialDto>>(testimonials));
        }

        public async Task<CustomResponseDto<TestimonialDto>> GetOneTestimonialAsync(int testimonialId)
        {
            Testimonial? currentEntity = await CheckEntityAsync(false, testimonialId);
            return CustomResponseDto<TestimonialDto>.Success(200, _mapper.Map<TestimonialDto>(currentEntity));  
        }

        public async Task<CustomResponseDto<NoContentDto>> SoftDeleteOneTestimonialAsync(int testimonialId)
        {
            Testimonial? currentEntity = await CheckEntityAsync(true, testimonialId);
            currentEntity.IsActive = false;
            currentEntity.IsDeleted = true;
            currentEntity.ModifiedDate = DateTime.UtcNow;

            await _unitOfWork.CommitAsync();
            return CustomResponseDto<NoContentDto>.Success(204);
        }

        public async Task<CustomResponseDto<TestimonialDtoForUpdate>> UpdateOneTestimonialAsync(int testimonialId,TestimonialDtoForUpdate testimonialDtoForUpdate)
        {
            if(testimonialDtoForUpdate is null)
                throw new ArgumentNullBadRequestException();
            if(testimonialDtoForUpdate.Id != testimonialId)
                throw new EntityNotMatchedParameterBadRequestException();
            Testimonial? currentTestimonial = await CheckEntityAsync(true, testimonialId);
            currentTestimonial.IsActive = testimonialDtoForUpdate.IsActive;
            currentTestimonial.IsDeleted = testimonialDtoForUpdate.IsActive ? false : true;
            currentTestimonial.Star = testimonialDtoForUpdate.Star;
            currentTestimonial.ImageUrl = testimonialDtoForUpdate.ImageUrl;
            currentTestimonial.Title = testimonialDtoForUpdate.Title;
            currentTestimonial.Name = testimonialDtoForUpdate.Name;
            currentTestimonial.Comment = testimonialDtoForUpdate.Comment;
            await _unitOfWork.CommitAsync();
            return CustomResponseDto<TestimonialDtoForUpdate>.Success(200,_mapper.Map<TestimonialDtoForUpdate>(currentTestimonial));

        }
        private async Task<Testimonial> CheckEntityAsync(bool trackChanges, int testimonialId)
        {
            Testimonial? currentEntity = await _repositoryManager.TestimonialRepository.GetByFilter(trackChanges,x => x.Id.Equals(testimonialId)).SingleOrDefaultAsync();
            if(currentEntity== null)
                throw new TestimonialNotFoundException(testimonialId);
            return currentEntity;
        }
    }
}
