using NotificationMicroservice.Contracts.Events.Base;
using NotificationMicroservice.Domain.Enums;

namespace NotificationMicroservice.Contracts.Events
{
    public record ConfirmationEmailEvent(Event Id, ConfirmationEmail Data) : IDefaultEvent<ConfirmationEmail>;
}
