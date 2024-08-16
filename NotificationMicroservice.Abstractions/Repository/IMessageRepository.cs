using NotificationMicroservice.Domain.Entities;

namespace NotificationMicroservice.Domain.Interfaces.Repository
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
