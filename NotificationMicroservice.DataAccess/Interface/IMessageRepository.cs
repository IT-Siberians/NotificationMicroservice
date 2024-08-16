using NotificationMicroservice.Domain.Entities;
using NotificationMicroservice.Domain.Interfaces.Repository;

namespace NotificationMicroservice.DataAccess.Interfaces
{
    /// <summary>
    /// Описания методов для репозитория Сообщений.
    /// </summary>
    public interface IMessageRepository : IRepository<Message, Guid>
    {
        /// <summary>
        /// Добавить в базу одну сущность.
        /// </summary>
        /// <param name="entity"> Сущность для добавления. </param>
        /// <param name="cancellationToken"> Токен отмены. </param>
        /// <returns> Добавленная сущность. </returns>
        Task<Guid> AddAsync(Message entity, CancellationToken cancellationToken);
    }
}
