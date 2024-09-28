using NotificationMicroservice.Application.Model.Abstractions;

namespace NotificationMicroservice.Application.Model.User
{
    public record UpdateUserModel(
        Guid Id,
        string FullName,
        string Email) : IBaseModel<Guid>;
}
