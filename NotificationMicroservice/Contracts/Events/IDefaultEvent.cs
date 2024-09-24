using NotificationMicroservice.Domain.Enums;

namespace NotificationMicroservice.Contracts.Events
{
    public interface IDefaultEvent<TEvent>
    {
        Event Id { get; }
        TEvent Data { get; }
    }
}
