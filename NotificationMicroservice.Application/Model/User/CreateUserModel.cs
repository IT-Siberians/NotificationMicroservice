using NotificationMicroservice.Application.Model.Abstractions;

namespace NotificationMicroservice.Application.Model.User
{
    public record CreateUserModel(
        Guid Id,
        string Username,
        string FullName,
        string Email
        ) : ICreateModel;
}
