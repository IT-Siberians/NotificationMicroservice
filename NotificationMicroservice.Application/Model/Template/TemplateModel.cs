using NotificationMicroservice.Application.Model.Abstractions;
using NotificationMicroservice.Application.Model.Type;
using NotificationMicroservice.Application.Model.User;

namespace NotificationMicroservice.Application.Model.Template
{
    public record TemplateModel(
        Guid Id,
        string Language,
        string Template,
        bool IsRemoved,
        UserModel CreatedByUser,
        DateTime CreationDate,
        UserModel? ModifiedByUser,
        DateTime? ModificationDate,
        TypeModel Type) : IBaseModel<Guid>;
}