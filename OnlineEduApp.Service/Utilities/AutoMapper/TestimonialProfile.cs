using AutoMapper;
using OnlineEduApp.Core.DTOs.TestimonialDTOs;
using OnlineEduApp.Core.Entities.Concretes;

namespace OnlineEduApp.Service.Utilities.AutoMapper
{
    public class TestimonialProfile : Profile
    {
        public TestimonialProfile()
        {
            CreateMap<Testimonial,TestimonialDto>().ReverseMap();
            CreateMap<Testimonial, TestimonialDtoForCreate>().ReverseMap();
            CreateMap<Testimonial, TestimonialDtoForUpdate>().ReverseMap();

            CreateMap<TestimonialDtoForCreate, TestimonialDto>().ReverseMap();
            CreateMap<TestimonialDtoForUpdate, TestimonialDto>().ReverseMap();
            CreateMap<TestimonialDtoForCreate, TestimonialDtoForUpdate>().ReverseMap();
        }
    }
}
