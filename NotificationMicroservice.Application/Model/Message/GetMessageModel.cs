namespace NotificationMicroservice.Application.Model.Message
{
    public record GetMessageModel(
        string Email,
        string Username,
        Uri Link);
}
