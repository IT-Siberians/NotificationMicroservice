namespace NotificationMicroservice.Application.Model.Message
{
    public record SendMessageModel(
        string Name,
        string Email,
        string MessageType,
        string MessageText);
}
