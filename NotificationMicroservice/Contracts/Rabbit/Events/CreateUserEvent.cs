namespace NotificationMicroservice.Contracts.Rabbit.Events
{
    public record CreateUserEvent(Guid Id, string Username, string FullName, string Email);
}
