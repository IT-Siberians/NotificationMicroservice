using NotificationMicroservice.Application.Model.Abstractions;

namespace NotificationMicroservice.Application.Model.User
{
    public class UserModel : IBaseModel<Guid>
    {
        public Guid Id { get; init; }
        public string Username { get; init; } = string.Empty;
        public string FullName { get; init; } = string.Empty;
        public string Email { get; init; } = string.Empty;
        public DateTime CreationDate { get; init; }
    }
}
