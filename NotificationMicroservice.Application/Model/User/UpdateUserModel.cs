namespace NotificationMicroservice.Application.Model.User
{
    public class UpdateUserModel : IBaseModel<Guid>
    {
        public Guid Id { get; init; }
        public string FullName { get; init; } = string.Empty;
        public string Email { get; init; } = string.Empty;

    }
}
