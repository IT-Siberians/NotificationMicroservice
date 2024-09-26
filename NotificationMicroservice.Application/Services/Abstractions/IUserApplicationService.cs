using NotificationMicroservice.Application.Model.User;
using NotificationMicroservice.Application.Services.Abstractions.Base;

namespace NotificationMicroservice.Application.Services.Abstractions
{
    public interface IUserApplicationService : IUpdateService<UserModel, CreateUserModel, UpdateUserModel, Guid>
    {
    }
}
