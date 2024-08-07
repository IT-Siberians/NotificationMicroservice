using AutoMapper;
using NotificationMicroservice.Application.Model.Message;
using NotificationMicroservice.Application.Model.Template;
using NotificationMicroservice.Application.Model.Type;
using NotificationMicroservice.Contracts.Message;
using NotificationMicroservice.Contracts.Template;
using NotificationMicroservice.Contracts.Type;

namespace NotificationMicroservice.Mapper
{
    public class ProfilePre : Profile
    {
        public ProfilePre() 
        {
            CreateMap<TypeRequestAdd, CreateTypeModel>();
            CreateMap<TypeRequestUp, EditTypeModel>();
            CreateMap<TypeRequestDelete, EditTypeModel>();
            CreateMap<TypeModel, TypeResponse>();

            CreateMap<MessageModel, MessageResponse>();

            CreateMap<TemplateModel, TemplateResponse>();
            CreateMap<TemplateRequestAdd, CreateTemplateModel>();
            CreateMap<TemplateRequestUp, EditTemplateModel>();
        }        
    }
}
