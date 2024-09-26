using NotificationMicroservice.Contracts.Type;

namespace NotificationMicroservice.Contracts.Template
{
    public record TemplateResponse(
        Guid Id,
        TypeResponse Type,
        string Language,
        string Template,
        bool IsRemoved,
        Guid CreatedByUserId,
        DateTime CreationDate,
        Guid? ModifiedByUserId,
        DateTime? ModificationDate
        );

}
