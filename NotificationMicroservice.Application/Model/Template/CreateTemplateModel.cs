namespace NotificationMicroservice.Application.Model.Template
{
    public record CreateTemplateModel(
        Guid MessageTypeId,
        string Language,
        string Template,
        string CreateUserName
        );
}
