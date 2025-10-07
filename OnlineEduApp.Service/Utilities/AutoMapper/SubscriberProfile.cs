using AutoMapper;
using OnlineEduApp.Core.DTOs.SubscriberDTOs;
using OnlineEduApp.Core.Entities.Concretes;

namespace OnlineEduApp.Service.Utilities.AutoMapper
{
    public class SubscriberProfile : Profile
    {
        public SubscriberProfile()
        {
            CreateMap<Subscriber,SubscriberDto>().ReverseMap();
            CreateMap<Subscriber, SubscriberDtoForCreate>().ReverseMap();
            CreateMap<Subscriber, SubscriberDtoForUpdate>().ReverseMap();

            CreateMap<SubscriberDtoForCreate, SubscriberDto>().ReverseMap();
            CreateMap<SubscriberDtoForUpdate, SubscriberDto>().ReverseMap();
            CreateMap<SubscriberDtoForCreate, SubscriberDtoForUpdate>().ReverseMap();
        }
    }
}
