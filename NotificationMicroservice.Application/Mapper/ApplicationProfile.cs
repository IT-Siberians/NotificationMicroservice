using AutoMapper;
using NotificationMicroservice.Application.Model.Message;
using NotificationMicroservice.Application.Model.Template;
using NotificationMicroservice.Application.Model.Type;
using NotificationMicroservice.Domain.Entities;


namespace NotificationMicroservice.Application.Mapper
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<MessageType, TypeModel>().ReverseMap();
            CreateMap<MessageTemplate, TemplateModel>().ReverseMap();
            CreateMap<Message, MessageModel>().ReverseMap();
        }
    }
}
