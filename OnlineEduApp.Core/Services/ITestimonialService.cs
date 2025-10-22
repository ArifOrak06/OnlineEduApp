using OnlineEduApp.Core.DTOs.TestimonialDTOs;
using OnlineEduApp.Core.Entities.RequestFeatures;
using OnlineEduApp.SharedLibrary.Response;
using OnlineEduApp.SharedLibrary.ResponseResultPattern;

namespace OnlineEduApp.Core.Services
{
    public interface ITestimonialService
    {
        Task<(CustomResponseDto<List<TestimonialDto>> responseDto, MetaData metaData)> GetAllTestimonialsAsync(TestimonialParameters testimonialParameters);
        Task<(CustomResponseDto<List<TestimonialDto>> responseDto, MetaData metaData)> GetAllDeletedTestimonialsAsync(TestimonialParameters testimonialParameters);
        Task<CustomResponseDto<List<TestimonialDto>>> GetAllTestimonialsNoPaggingAsync();
        Task<CustomResponseDto<TestimonialDto>> GetOneTestimonialAsync(int testimonialId);
        Task<CustomResponseDto<TestimonialDtoForCreate>> CreateOneTestimonialAsync(TestimonialDtoForCreate testimonialDtoForCreate);
        Task<CustomResponseDto<TestimonialDtoForUpdate>> UpdateOneTestimonialAsync(int testimonialId, TestimonialDtoForUpdate testimonialDtoForUpdate);
        Task<CustomResponseDto<NoContentDto>> SoftDeleteOneTestimonialAsync(int testimonialId);
        Task<CustomResponseDto<NoContentDto>> DeleteOneTestimonialAsync(int testimonialId);


    }
}
