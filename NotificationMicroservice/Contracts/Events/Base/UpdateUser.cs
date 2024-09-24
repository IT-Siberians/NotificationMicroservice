using NotificationMicroservice.Domain.Enums;

namespace NotificationMicroservice.Contracts.Events.Base
{
    public record UpdateUser(Guid Id, string FullName, string Email);
}
