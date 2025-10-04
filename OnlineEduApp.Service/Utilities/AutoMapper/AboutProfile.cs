using AutoMapper;
using OnlineEduApp.Core.DTOs.AboutDTOs;
using OnlineEduApp.Core.Entities.Concretes;

namespace OnlineEduApp.Service.Utilities.AutoMapper
{
    public class AboutProfile : Profile
    {
        public AboutProfile()
        {
            CreateMap<About, AboutDto>().ReverseMap();
            CreateMap<About, AboutDtoForUpdate>().ReverseMap();
            CreateMap<About, AboutDtoForCreate>().ReverseMap();
        }

       
    }
}
