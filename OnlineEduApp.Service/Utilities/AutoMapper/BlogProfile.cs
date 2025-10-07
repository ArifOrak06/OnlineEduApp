using AutoMapper;
using OnlineEduApp.Core.DTOs.BlogDTOs;
using OnlineEduApp.Core.Entities.Concretes;

namespace OnlineEduApp.Service.Utilities.AutoMapper
{
    public class BlogProfile: Profile
    {

        public BlogProfile()
        {
            CreateMap<Blog, BlogDto>().ReverseMap();
            CreateMap<Blog, BlogDtoForCreate>().ReverseMap();
            CreateMap<Blog, BlogDtoForUpdate>().ReverseMap();

            CreateMap<BlogDto, BlogDtoForCreate>().ReverseMap();
            CreateMap<BlogDto, BlogDtoForUpdate>().ReverseMap();
            CreateMap<BlogDtoForCreate, BlogDtoForUpdate>().ReverseMap();
        }
    }
}
