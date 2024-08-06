using NotificationMicroservice.Contracts.Type;

namespace NotificationMicroservice.Contracts.Template
{
    public record TemplateResponse(
        Guid Id,
        TypeResponse Type,
        string Language,
        string Template,
        bool IsRemove,
        string CreateUserName,
        DateTime CreateDate,
        string? ModifyUserName,
        DateTime? ModifyDate
        );

}
