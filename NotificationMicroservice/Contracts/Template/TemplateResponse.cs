using NotificationMicroservice.Contracts.Type;

namespace NotificationMicroservice.Contracts.Template
{
    public record TemplateResponse(
        Guid Id,
        TypeResponse Type,
        string Language,
        string Template,
        bool IsRemoved,
        Guid CreatedUserId,
        DateTime CreationDate,
        Guid? ModifiedUserId,
        DateTime? ModifiedDate
        );

}
