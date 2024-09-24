namespace NotificationMicroservice.Contracts.Events.Base
{
    public record ConfirmationEmail(
        string Email,
        string Username,
        Uri Link);
}
