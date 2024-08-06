namespace NotificationMicroservice.Application.Model.Template
{
    public record EditTemplateModel(
        Guid Id,
        Guid MessageTypeId,
        string Language,
        string Template,
        bool IsRemove,
        string ModifyUserName
        );
}
