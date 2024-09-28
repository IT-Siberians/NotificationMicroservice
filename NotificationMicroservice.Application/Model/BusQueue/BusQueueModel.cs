using NotificationMicroservice.Application.Model.Abstractions;
using NotificationMicroservice.Application.Model.Type;
using NotificationMicroservice.Application.Model.User;

namespace NotificationMicroservice.Application.Model.BusQueue
{
    public record BusQueueModel(
        Guid Id,
        string QueueName,
        TypeModel Type,
        bool IsRemoved,
        UserModel CreatedByUser,
        DateTime CreationDate,
        UserModel? ModifiedByUser,
        DateTime? ModificationDate) : IBaseModel<Guid>;
}
