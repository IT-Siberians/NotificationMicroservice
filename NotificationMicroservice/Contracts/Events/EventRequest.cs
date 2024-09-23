using NotificationMicroservice.Contracts.Message;
using NotificationMicroservice.Domain.Enums;

namespace NotificationMicroservice.Contracts.Events
{
    public record EventRequest(Event id, MessageRequest data);
}
