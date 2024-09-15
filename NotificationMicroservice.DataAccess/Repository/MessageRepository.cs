using Microsoft.EntityFrameworkCore;
using NotificationMicroservice.DataAccess.Repository.Abstractions;
using NotificationMicroservice.Domain.Entities;

namespace NotificationMicroservice.DataAccess.Repository
{
    /// <summary>
    /// Репозиторий для работы с сообщениями в базе данных.
    /// Реализует интерфейс <see cref="IMessageRepository"/>.
    /// </summary>
    /// <param name="context">Контекст базы данных для работы с сообщениями.</param>
    public class MessageRepository(NotificationMicroserviceDbContext context) : IMessageRepository
    {
        /// <summary>
        /// Запрашивает все сообщения из базы данных.
        /// </summary>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        /// <param name="asNoTracking">Указывает, следует ли использовать режим <c>AsNoTracking</c> для запросов.</param>
        /// <returns>Список всех сущностей типа <see cref="Message"/>.</returns>
        public async Task<IEnumerable<Message>> GetAllAsync(CancellationToken cancellationToken, bool asNoTracking = false)
        {
            return await (asNoTracking ? context.Messages.AsNoTracking() : context.Messages)
                .ToListAsync(cancellationToken);
        }

        /// <summary>
        /// Запрашивает сообщение по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор сообщения.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        /// <returns>Сущность типа <see cref="Message"/> с заданным идентификатором или <c>null</c>, если не найдено.</returns>
        public async Task<Message?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await context.Messages
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        /// <summary>
        /// Добавляет новое сообщение в базу данных.
        /// </summary>
        /// <param name="message">Сущность сообщения для добавления.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        /// <returns>Идентификатор добавленного сообщения.</returns>
        public async Task<Guid> AddAsync(Message message, CancellationToken cancellationToken)
        {
            context.Types.Attach(message.Type);
            await context.Messages.AddAsync(message);
            await context.SaveChangesAsync();

            return message.Id;
        }
    }
}
