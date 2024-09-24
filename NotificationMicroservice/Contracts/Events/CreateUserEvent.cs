using NotificationMicroservice.Contracts.Events.Base;
using NotificationMicroservice.Domain.Enums;

namespace NotificationMicroservice.Contracts.Events
{
    public record CreateUserEvent(Event Id, CreateUser Data) : IDefaultEvent<CreateUser>;
}
