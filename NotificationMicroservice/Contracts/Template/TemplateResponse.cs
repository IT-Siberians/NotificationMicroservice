namespace NotificationMicroservice.Contracts.Template
{
    public record TemplateResponse(
        Guid Id,
        string MessageTypeName,
        Guid MessageTypeId,
        string Language,
        string Template,
        bool IsRemove,
        string CreateUserName,
        DateTime CreateDate,
        string? ModifyUserName,
        DateTime? ModifyDate
        );

}
