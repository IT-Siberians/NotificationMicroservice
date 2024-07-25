namespace NotificationMicroservice.Contracts.Template
{
    public record TemplateRequestAdd(
        string MessageTypeName,
        Guid MessageTypeId,
        string Language,
        string Template,
        string CreateUserName
        );

}
