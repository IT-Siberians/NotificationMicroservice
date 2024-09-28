using NotificationMicroservice.Application.Model.Abstractions;

namespace NotificationMicroservice.Application.Model.BusQueue
{
    public record CreateBusQueueModel(
        string QueueName,
        Guid MessageTypeId,
        Guid CreatedByUserId) : ICreateModel;
}
