namespace NotificationMicroservice.Contracts.Events.Base
{
    public record CreateUser(Guid Id, string Username, string FullName, string Email);
}
