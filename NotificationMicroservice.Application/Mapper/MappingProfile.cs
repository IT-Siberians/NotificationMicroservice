using AutoMapper;
using NotificationMicroservice.DataAccess.Entities;
using NotificationMicroservice.Domain.Models;

namespace NotificationMicroservice.Application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            //CreateMap<Message, MessageEntity>().ReverseMap();
            //CreateMap<MessageType, TypeEntity>().ReverseMap();
            //CreateMap<MessageTemplate, TemplateEntity>().ReverseMap();
        }
    }
}
