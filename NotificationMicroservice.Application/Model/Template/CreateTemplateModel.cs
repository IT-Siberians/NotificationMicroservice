using NotificationMicroservice.Application.Model.Abstractions;

namespace NotificationMicroservice.Application.Model.Template
{
    public record CreateTemplateModel(
        Guid MessageTypeId,
        string Language,
        string Template,
        Guid CreatedByUserId
        ) : ICreateModel;
}
