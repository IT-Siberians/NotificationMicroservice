namespace NotificationMicroservice.Contracts.Template
{
    public record AddTemplateRequest(
        Guid MessageTypeId,
        string Language,
        string Template,
        string CreatedUserName
        );

}
