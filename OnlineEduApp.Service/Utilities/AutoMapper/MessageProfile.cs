using AutoMapper;
using OnlineEduApp.Core.DTOs.MessageDTOs;
using OnlineEduApp.Core.Entities.Concretes;

namespace OnlineEduApp.Service.Utilities.AutoMapper
{
    public class MessageProfile : Profile
    {
        public MessageProfile()
        {
            CreateMap<Message, MessageDto>().ReverseMap();
            CreateMap<Message, MessageDtoForCreate>().ReverseMap();
            CreateMap<Message, MessageDtoForUpdate>().ReverseMap();

            CreateMap<MessageDtoForCreate, MessageDto>().ReverseMap();
            CreateMap<MessageDtoForUpdate, MessageDto>().ReverseMap();
            CreateMap<MessageDtoForCreate, MessageDtoForUpdate>().ReverseMap();
        }
    }
}
