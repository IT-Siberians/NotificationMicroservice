using AutoMapper;
using NotificationMicroservice.Application.Model.Message;
using NotificationMicroservice.Application.Model.Template;
using NotificationMicroservice.Application.Model.Type;
using NotificationMicroservice.Contracts.Message;
using NotificationMicroservice.Contracts.Template;
using NotificationMicroservice.Contracts.Type;

namespace NotificationMicroservice.Mapper
{
    public class PresentationProfile : Profile
    {
        public PresentationProfile()
        {
            CreateMap<TypeAddRequest, CreateTypeModel>();
            CreateMap<TypeEditRequest, EditTypeModel>();
            CreateMap<TypeDeleteRequest, EditTypeModel>();
            CreateMap<TypeModel, TypeResponse>();

            CreateMap<MessageModel, MessageResponse>();

            CreateMap<TemplateModel, TemplateResponse>();
            CreateMap<TemplateAddRequest, CreateTemplateModel>();
            CreateMap<TemplateEditRequest, EditTemplateModel>();
        }
    }
}
