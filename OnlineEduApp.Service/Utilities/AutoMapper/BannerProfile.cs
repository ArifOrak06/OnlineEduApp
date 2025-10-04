using AutoMapper;
using OnlineEduApp.Core.DTOs.BannerDTOs;
using OnlineEduApp.Core.Entities.Concretes;

namespace OnlineEduApp.Service.Utilities.AutoMapper
{
    public class BannerProfile : Profile
    {
        public BannerProfile()
        {
            CreateMap<Banner, BannerDto>().ReverseMap();
            CreateMap<Banner, BannerDtoForCreate>().ReverseMap();
            CreateMap<Banner, BannerDtoForUpdate>().ReverseMap();

            CreateMap<BannerDto, BannerDtoForUpdate>().ReverseMap();
            CreateMap<BannerDto, BannerDtoForCreate>().ReverseMap();
        }
    }
}
