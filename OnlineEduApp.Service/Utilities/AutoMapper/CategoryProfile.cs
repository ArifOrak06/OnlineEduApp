using AutoMapper;
using OnlineEduApp.Core.DTOs.CategoryDTOs;
using OnlineEduApp.Core.Entities.Concretes;

namespace OnlineEduApp.Service.Utilities.AutoMapper
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category,CategoryDto>().ReverseMap();
            CreateMap<Category, CategoryDtoForCreate>().ReverseMap();
            CreateMap<Category, CategoryDtoForUpdate>().ReverseMap();

            CreateMap<CategoryDto, CategoryDtoForCreate>().ReverseMap();
            CreateMap<CategoryDto, CategoryDtoForUpdate>().ReverseMap();
            CreateMap<CategoryDtoForCreate, CategoryDtoForUpdate>().ReverseMap();
        }
    } 
}
