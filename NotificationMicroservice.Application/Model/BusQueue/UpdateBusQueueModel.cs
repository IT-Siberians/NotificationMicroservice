using NotificationMicroservice.Application.Model.Abstractions;

namespace NotificationMicroservice.Application.Model.BusQueue
{
    public class UpdateBusQueueModel : IBaseModel<Guid>
    {
        public Guid Id { get; set; }
        public Guid MessageTypeId { get; init; }
        public bool IsRemoved { get; init; }
        public Guid ModifiedByUserId { get; init; }
    }
}
