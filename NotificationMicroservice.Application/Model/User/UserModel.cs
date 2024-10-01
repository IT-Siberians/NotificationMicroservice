using NotificationMicroservice.Application.Model.Abstractions;

namespace NotificationMicroservice.Application.Model.User
{
    public record UserModel(
        Guid Id,
        string Username,
        string FullName,
        string Email,
        DateTime CreationDate) : IBaseModel<Guid>;
}
