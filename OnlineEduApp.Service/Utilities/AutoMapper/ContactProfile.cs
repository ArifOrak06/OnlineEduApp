using AutoMapper;
using OnlineEduApp.Core.DTOs.ContactDTOs;
using OnlineEduApp.Core.Entities.Concretes;

namespace OnlineEduApp.Service.Utilities.AutoMapper
{
    public class ContactProfile : Profile
    {
        public ContactProfile()
        {
            CreateMap<Contact, ContactDto>().ReverseMap();
            CreateMap<Contact, ContactDtoForCreate>().ReverseMap();
            CreateMap<Contact, ContactDtoForUpdate>().ReverseMap();

            CreateMap<ContactDtoForCreate, ContactDto>().ReverseMap();
            CreateMap<ContactDtoForUpdate, ContactDto>().ReverseMap();
            CreateMap<ContactDtoForCreate, ContactDtoForUpdate>().ReverseMap();
        }
    }
}
