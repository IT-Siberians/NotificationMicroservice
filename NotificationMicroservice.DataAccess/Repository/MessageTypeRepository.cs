using Microsoft.EntityFrameworkCore;
using NotificationMicroservice.DataAccess.Repository.Abstractions;
using NotificationMicroservice.Domain.Entities;

namespace NotificationMicroservice.DataAccess.Repository
{
    /// <summary>
    /// Репозиторий для работы с типами сообщений в базе данных.
    /// Реализует интерфейс <see cref="IMessageTypeRepository"/>.
    /// </summary>
    /// <param name="context">Контекст базы данных для работы с сообщениями.</param>
    public class MessageTypeRepository(NotificationMicroserviceDbContext context) : BaseRepository<MessageType, Guid>(context), IMessageTypeRepository
    {
        /// <summary>
        /// Добавляет новый тип сообщения в базу данных.
        /// </summary>
        /// <param name="type">Сущность типа сообщения для добавления.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        /// <returns>Идентификатор добавленного типа сообщения.</returns>
        public async Task<Guid> AddAsync(MessageType type, CancellationToken cancellationToken = default)
        {
            context.Users.Attach(type.CreatedByUser);
            context.Types.Add(type);
            await context.SaveChangesAsync(cancellationToken);

            return type.Id;
        }

        /// <summary>
        /// Обновляет существующий тип сообщения в базе данных.
        /// </summary>
        /// <param name="type">Сущность типа сообщения с обновленными данными.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        /// <returns>Возвращает <c>true</c> после успешного обновления.</returns>
        public async Task<bool> UpdateAsync(MessageType type, CancellationToken cancellationToken = default)
        {
            context.Entry(type).State = EntityState.Modified;
            context.Users.Attach(type.ModifiedByUser!);

            return await context.SaveChangesAsync(cancellationToken) > 0;
        }

        /// <summary>
        /// Помечает тип сообщения как удаленный в базе данных.
        /// </summary>
        /// <param name="type">Сущность типа сообщения с обновленными данными.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        /// <returns>Возвращает <c>true</c> после успешного удаления.</returns>
        public async Task<bool> DeleteAsync(MessageType type, CancellationToken cancellationToken = default)
        {
            return await UpdateAsync(type, cancellationToken);
        }
    }
}
