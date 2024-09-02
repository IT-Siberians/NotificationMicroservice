namespace NotificationMicroservice.Application.Model.User
{
    public class UserModel
    {
        public Guid Id { get; init; }
        public string UserName { get; init; }
        public string FullName { get; init; }
        public string Email { get; init; }
        public DateTime CreationDate { get; init; }
    }
}
