using NotificationMicroservice.Contracts.Type;

namespace NotificationMicroservice.Contracts.Message
{
    public record MessageResponse(
        Guid Id,
        TypeResponse Type,
        string MessageText,
        string Direction,
        DateTime CreationDate);
}
