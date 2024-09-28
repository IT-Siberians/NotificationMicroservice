using AutoMapper;
using NotificationMicroservice.Application.Model.BusQueue;
using NotificationMicroservice.Application.Model.Message;
using NotificationMicroservice.Application.Model.Template;
using NotificationMicroservice.Application.Model.Type;
using NotificationMicroservice.Application.Model.User;
using NotificationMicroservice.Contracts.BusQueue;
using NotificationMicroservice.Contracts.Message;
using NotificationMicroservice.Contracts.Rabbit.Events;
using NotificationMicroservice.Contracts.Template;
using NotificationMicroservice.Contracts.Type;

namespace NotificationMicroservice.Mapper
{
    public class PresentationProfile : Profile
    {
        public PresentationProfile()
        {
            CreateMap<TypeModel, TypeResponse>();
            CreateMap<AddTypeRequest, CreateTypeModel>();
            CreateMap<EditTypeRequest, UpdateTypeModel>();
            CreateMap<DeleteTypeRequest, DeleteTypeModel>();

            CreateMap<MessageModel, MessageResponse>();

            CreateMap<TemplateModel, TemplateResponse>();
            CreateMap<AddTemplateRequest, CreateTemplateModel>();
            CreateMap<EditTemplateRequest, UpdateTemplateModel>();
            CreateMap<DeleteTemplateRequest, DeleteTemplateModel>();

            CreateMap<CreateUserEvent, CreateUserModel>().ReverseMap();
            CreateMap<UpdateUserEvent, UpdateUserModel>().ReverseMap();

            CreateMap<BusQueueModel, BusQueueResponse>();
            CreateMap<AddBusQueueRequest, CreateBusQueueModel>();
            CreateMap<EditBusQueueRequest, UpdateBusQueueModel>();
            CreateMap<DeleteBusQueueRequest, DeleteBusQueueModel>();
        }
    }
}
