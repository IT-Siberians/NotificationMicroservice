using AutoMapper;
using NotificationMicroservice.Application.Model.Message;
using NotificationMicroservice.Application.Model.Template;
using NotificationMicroservice.Application.Model.Type;
using NotificationMicroservice.Application.Model.User;
using NotificationMicroservice.Domain.Entities;


namespace NotificationMicroservice.Application.Mapper
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<MessageType, TypeModel>()
                .ForMember(d => d.Name, o => o.MapFrom(s => s.Name.Value))
                .ReverseMap();
            CreateMap<MessageTemplate, TemplateModel>().ReverseMap();
            CreateMap<Message, MessageModel>().ReverseMap();
            CreateMap<User, UserModel>()
                .ForMember(d => d.Username, o => o.MapFrom(s => s.Username.Value))
                .ForMember(d => d.FullName, o => o.MapFrom(s => s.FullName.Value))
                .ForMember(d => d.Email, o => o.MapFrom(s => s.Email.Value))
                .ReverseMap();
        }
    }
}
