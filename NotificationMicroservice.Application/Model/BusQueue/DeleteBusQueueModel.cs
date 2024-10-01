using NotificationMicroservice.Application.Model.Abstractions;

namespace NotificationMicroservice.Application.Model.BusQueue
{
    public class DeleteBusQueueModel : IBaseModel<Guid>
    {
        public Guid Id { get; set; }
        public required Guid ModifiedByUserId { get; set; }
    }
}
