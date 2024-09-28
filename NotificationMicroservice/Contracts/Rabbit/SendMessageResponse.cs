namespace NotificationMicroservice.Contracts.Rabbit
{
    public record SendMessageResponse(
        string Name,
        string Email,
        string MessageType,
        string MessageText);
}
