using NotificationMicroservice.Contracts.Type;

namespace NotificationMicroservice.Contracts.BusQueue
{
    public record BusQueueResponse(
        Guid Id,
        string QueueName,
        TypeResponse Type,
        bool IsRemoved,
        Guid CreatedByUserId,
        DateTime CreationDate,
        Guid? ModifiedByUserId,
        DateTime? ModificationDate
        );
}
