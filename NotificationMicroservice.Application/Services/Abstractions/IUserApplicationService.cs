using NotificationMicroservice.Application.Model.User;
using NotificationMicroservice.Application.Services.Abstractions.Base;

namespace NotificationMicroservice.Application.Services.Abstractions
{
    /// <summary>
    /// Интерефейс для сервиса работы с пользователями
    /// </summary>
    public interface IUserApplicationService : IUpdateService<UserModel, CreateUserModel, UpdateUserModel, Guid>
    {
    }
}
