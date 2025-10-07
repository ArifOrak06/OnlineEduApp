using AutoMapper;
using OnlineEduApp.Core.DTOs.SocialMediaDTOs;
using OnlineEduApp.Core.Entities.Concretes;

namespace OnlineEduApp.Service.Utilities.AutoMapper
{
    public class SocialMediaProfile : Profile
    {
        public SocialMediaProfile()
        {
            CreateMap<SocialMedia,SocialMediaDto>().ReverseMap();
            CreateMap<SocialMedia, SocialMediaDtoForCreate>().ReverseMap();
            CreateMap<SocialMedia, SocialMediaDtoForUpdate>().ReverseMap();

            CreateMap<SocialMediaDto, SocialMediaDtoForCreate>().ReverseMap();
            CreateMap<SocialMediaDto, SocialMediaDtoForUpdate>().ReverseMap();
            CreateMap<SocialMediaDtoForCreate, SocialMediaDtoForUpdate>().ReverseMap();
        }
    }
}
