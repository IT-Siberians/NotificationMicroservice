using NotificationMicroservice.DataAccess.Repository.Abstractions.Base;
using NotificationMicroservice.Domain.Entities;

namespace NotificationMicroservice.DataAccess.Repository.Abstractions
{
    /// <summary>
    /// Интерфейс репозитория для управления объектами типа <see cref="Message"/>.
    /// </summary>
    public interface IMessageRepository : IRepository<Message, Guid>
    {
        /// <summary>
        /// Асинхронно добавляет сообщение в базу данных.
        /// </summary>
        /// <param name="entity">Сущность для добавления.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Добавленная сущность.</returns>
        Task<Guid> AddAsync(Message entity, CancellationToken cancellationToken);
    }
}
