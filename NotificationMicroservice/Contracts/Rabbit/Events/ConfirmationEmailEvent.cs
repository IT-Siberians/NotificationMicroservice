namespace NotificationMicroservice.Contracts.Rabbit.Events
{
    public record ConfirmationEmailEvent(
        string Email,
        string Username,
        Uri Link);
}
