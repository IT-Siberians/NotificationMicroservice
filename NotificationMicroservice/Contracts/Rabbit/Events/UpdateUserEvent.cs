namespace NotificationMicroservice.Contracts.Rabbit.Events
{
    public record UpdateUserEvent(Guid Id, string FullName, string Email);
}
