namespace NotificationMicroservice.Contracts.Message
{
    public record MessageRequest(
        string Email,
        string Username,
        Uri Link);
}
