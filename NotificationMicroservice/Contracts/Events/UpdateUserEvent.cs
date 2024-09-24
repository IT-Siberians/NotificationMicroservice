using NotificationMicroservice.Contracts.Events.Base;
using NotificationMicroservice.Domain.Enums;

namespace NotificationMicroservice.Contracts.Events
{
    public record UpdateUserEvent(Event Id, UpdateUser Data) : IDefaultEvent<UpdateUser>;

}
