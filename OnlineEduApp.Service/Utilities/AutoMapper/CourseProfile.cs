using AutoMapper;
using OnlineEduApp.Core.DTOs.CourseDTOs;
using OnlineEduApp.Core.Entities.Concretes;

namespace OnlineEduApp.Service.Utilities.AutoMapper
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            CreateMap<Course,CourseDto>().ReverseMap();
            CreateMap<Course, CourseDtoForCreate>().ReverseMap();
            CreateMap<Course, CourseDtoForUpdate>().ReverseMap();

            CreateMap<CourseDto, CourseDtoForCreate>().ReverseMap();
            CreateMap<CourseDto, CourseDtoForUpdate>().ReverseMap();
            CreateMap<CourseDtoForCreate, CourseDtoForUpdate>().ReverseMap();
        }
    }
}
