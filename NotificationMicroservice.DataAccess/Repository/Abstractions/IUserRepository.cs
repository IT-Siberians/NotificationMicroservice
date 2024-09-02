using NotificationMicroservice.DataAccess.Repository.Abstractions.Base;
using NotificationMicroservice.Domain.Entities;

namespace NotificationMicroservice.DataAccess.Repository.Abstractions
{
    /// <summary>
    /// Интерфейс репозитория для управления объектами типа <see cref="User"/>.
    /// </summary>
    public interface IUserRepository : IModifyRepository<User, Guid>
    {
    }
}
