namespace NotificationMicroservice.Contracts.Template
{
    public record TemplateAddRequest(
        Guid MessageTypeId,
        string Language,
        string Template,
        string CreateUserName
        );

}
