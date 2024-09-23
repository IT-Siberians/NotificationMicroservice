using NotificationMicroservice.Contracts.Type;
using NotificationMicroservice.Domain.Enums;

namespace NotificationMicroservice.Contracts.Message
{
    public record MessageResponse(
        Guid Id,
        TypeResponse Type,
        string Text,
        Direction Direction,
        DateTime CreationDate);
}
