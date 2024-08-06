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
            //#region MapType
            //CreateMap<TypeModel, TypeEntity>().ReverseMap();
            //CreateMap<TypeModel, MessageType>().ReverseMap();
            CreateMap<MessageType, TypeModel>().ReverseMap();
            CreateMap<MessageTemplate, TemplateModel>().ReverseMap();
            CreateMap<Message, MessageModel>().ReverseMap();
            //#endregion

            //#region MapTemplate
            //CreateMap<TemplateModel, TemplateEntity>().ReverseMap();
            //CreateMap<TemplateModel, MessageTemplate>().ReverseMap();
            //CreateMap<MessageTemplate, TemplateEntity>().ReverseMap();
            //#endregion

            //#region MapMessage
            ////
            //#endregion
        }
    }
}
