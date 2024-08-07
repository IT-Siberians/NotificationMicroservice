using AutoMapper;
using NotificationMicroservice.Application.Model.Message;
using NotificationMicroservice.Application.Model.Template;
using NotificationMicroservice.Application.Model.Type;
using NotificationMicroservice.Domain.Entity;


namespace NotificationMicroservice.Application.Mapper
{
    public class ProfileApp : Profile
    {
        public ProfileApp() 
        {
            CreateMap<MessageType, TypeModel>().ReverseMap();
            CreateMap<MessageTemplate, TemplateModel>().ReverseMap();
            CreateMap<Message, MessageModel>().ReverseMap();
        }
    }
}
