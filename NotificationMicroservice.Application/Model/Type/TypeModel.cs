using NotificationMicroservice.Application.Model.Abstractions;
using NotificationMicroservice.Application.Model.User;

namespace NotificationMicroservice.Application.Model.Type
{
    public record TypeModel(
        Guid Id,
        string Name,
        bool IsRemoved,
        UserModel CreatedByUser,
        DateTime CreationDate,
        UserModel? ModifiedByUser,
        DateTime? ModificationDate) : IBaseModel<Guid>;
}
