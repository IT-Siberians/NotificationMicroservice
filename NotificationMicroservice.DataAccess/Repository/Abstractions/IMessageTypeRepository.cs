using NotificationMicroservice.DataAccess.Repository.Abstractions.Base;
using NotificationMicroservice.Domain.Entities;

namespace NotificationMicroservice.DataAccess.Repository.Abstractions
{
    /// <summary>
    /// Интерфейс репозитория для управления объектами типа <see cref="MessageType"/>.
    /// </summary>
    public interface IMessageTypeRepository : IModifyRepository<MessageType, Guid>
    {
    }
}
