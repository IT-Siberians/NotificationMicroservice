namespace NotificationMicroservice.Contracts.BusQueue
{
    public record EditBusQueueRequest(
        Guid MessageTypeId,
        bool IsRemoved,
        Guid ModifiedByUserId);
}
