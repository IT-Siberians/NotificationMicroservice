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
    public class MessageTypeRepository(NotificationMicroserviceDbContext context) : IMessageTypeRepository
    {

        /// <summary>
        /// Запрашивает все типы сообщений из базы данных.
        /// </summary>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        /// <param name="asNoTracking">Указывает, следует ли использовать режим <c>AsNoTracking</c> для запросов.</param>
        /// <returns>Список всех сущностей типа <see cref="MessageType"/>.</returns>
        public async Task<IEnumerable<MessageType>> GetAllAsync(CancellationToken cancellationToken, bool asNoTracking = false)
        {
            return await (asNoTracking ? context.Types.AsNoTracking() : context.Types)
                .ToListAsync(cancellationToken);
        }

        /// <summary>
        /// Запрашивает тип сообщения по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор типа сообщения.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        /// <returns>Сущность типа <see cref="MessageType"/> с заданным идентификатором или <c>null</c>, если не найдено.</returns>
        public async Task<MessageType?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await context.Types
                .Where(x => x.Id == id)
                .AsNoTracking()
                .FirstOrDefaultAsync(cancellationToken);
        }

        /// <summary>
        /// Добавляет новый тип сообщения в базу данных.
        /// </summary>
        /// <param name="entity">Сущность типа сообщения для добавления.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        /// <returns>Идентификатор добавленного типа сообщения.</returns>
        public async Task<Guid> AddAsync(MessageType entity, CancellationToken cancellationToken)
        {
            await context.Types.AddAsync(entity, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }

        /// <summary>
        /// Обновляет существующий тип сообщения в базе данных.
        /// </summary>
        /// <param name="entity">Сущность типа сообщения с обновленными данными.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        /// <returns>Возвращает <c>true</c> после успешного обновления.</returns>
        public async Task<bool> UpdateAsync(MessageType entity, CancellationToken cancellationToken)
        {
            await context.Types
                .Where(x => x.Id == entity.Id)
                .ExecuteUpdateAsync(z => z
                    .SetProperty(a => a.Name, a => entity.Name)
                    .SetProperty(a => a.ModifiedUserName, a => entity.ModifiedUserName)
                    .SetProperty(a => a.ModifiedDate, a => entity.ModifiedDate), cancellationToken);

            return true;
        }

        /// <summary>
        /// Помечает тип сообщения как удаленный в базе данных.
        /// </summary>
        /// <param name="entity">Сущность типа сообщения с обновленными данными.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        /// <returns>Возвращает <c>true</c> после успешного удаления.</returns>
        public async Task<bool> DeleteAsync(MessageType entity, CancellationToken cancellationToken)
        {
            await context.Types
                .Where(x => x.Id == entity.Id)
                .ExecuteUpdateAsync(z => z
                    .SetProperty(a => a.IsRemove, a => entity.IsRemove)
                    .SetProperty(a => a.ModifiedUserName, a => entity.ModifiedUserName)
                    .SetProperty(a => a.ModifiedDate, a => entity.ModifiedDate), cancellationToken);

            return true;
        }
    }
}
