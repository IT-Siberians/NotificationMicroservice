namespace NotificationMicroservice.Application.Model.Template
{
    public record EditTemplateModel(
        Guid MessageTypeId,
        string Language,
        string Template,
        string ModifyUserName
        );
}
