using AutoMapper;
using NotificationMicroservice.Application.Model.Message;
using NotificationMicroservice.Application.Model.Template;
using NotificationMicroservice.Application.Model.Type;
using NotificationMicroservice.Application.Model.User;
using NotificationMicroservice.Contracts.Events.Base;
using NotificationMicroservice.Contracts.Message;
using NotificationMicroservice.Contracts.Template;
using NotificationMicroservice.Contracts.Type;

namespace NotificationMicroservice.Mapper
{
    public class PresentationProfile : Profile
    {
        public PresentationProfile()
        {
            CreateMap<AddTypeRequest, CreateTypeModel>();
            CreateMap<EditTypeRequest, UpdateTypeModel>();
            CreateMap<DeleteTypeRequest, DeleteTypeModel>();
            CreateMap<TypeModel, TypeResponse>();

            CreateMap<MessageModel, MessageResponse>();
            CreateMap<ConfirmationEmail, GetMessageModel>();
            CreateMap<CreateUserModel, CreateUser>().ReverseMap();
            CreateMap<UpdateUserModel, UpdateUser>().ReverseMap();

            CreateMap<TemplateModel, TemplateResponse>();
            CreateMap<AddTemplateRequest, CreateTemplateModel>();
            CreateMap<EditTemplateRequest, UpdateTemplateModel>();
            CreateMap<DeleteTemplateRequest, DeleteTemplateModel>();
        }
    }
}
