namespace NotificationMicroservice.Contracts.Template
{
    public record TemplateRequestUp(
        Guid MessageTypeId,
        string Language,
        string Template,
        string ModifyUserName
        );

}
