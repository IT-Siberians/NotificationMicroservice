namespace NotificationMicroservice.Contracts.Template
{
    public record TemplateEditRequest(
        Guid MessageTypeId,
        string Language,
        string Template,
        string ModifiedUserName
        );

}
