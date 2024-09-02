using Microsoft.EntityFrameworkCore;
using NotificationMicroservice.DataAccess.Repository.Abstractions;
using NotificationMicroservice.Domain.Entities;
using System.Reflection.Metadata;

namespace NotificationMicroservice.DataAccess.Repository
{
    /// <summary>
    /// Репозиторий для работы с шаблонами сообщений в базе данных.
    /// Реализует интерфейс <see cref="IMessageTemplateRepository"/>.
    /// </summary>
    /// <param name="context">Контекст базы данных для работы с сообщениями.</param>
    public class MessageTemplateRepository(NotificationMicroserviceDbContext context) : IMessageTemplateRepository
    {

        /// <summary>
        /// Запрашивает все шаблоны сообщений из базы данных.
        /// </summary>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        /// <param name="asNoTracking">Указывает, следует ли использовать режим <c>AsNoTracking</c> для запросов.</param>
        /// <returns>Список всех сущностей типа <see cref="MessageTemplate"/>.</returns>
        public async Task<IEnumerable<MessageTemplate>> GetAllAsync(CancellationToken cancellationToken, bool asNoTracking = false)
        {
            return await (asNoTracking ? context.Templates.AsNoTracking() : context.Templates)
                .ToListAsync(cancellationToken);
        }

        /// <summary>
        /// Запрашивает шаблон сообщения по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор шаблона сообщения.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        /// <returns>Сущность типа <see cref="MessageTemplate"/> с заданным идентификатором или <c>null</c>, если не найдено.</returns>
        public async Task<MessageTemplate?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await context.Templates
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        /// <summary>
        /// Добавляет новый шаблон сообщения в базу данных.
        /// </summary>
        /// <param name="entity">Сущность шаблона сообщения для добавления.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        /// <returns>Идентификатор добавленного шаблона сообщения.</returns>
        public async Task<Guid> AddAsync(MessageTemplate entity, CancellationToken cancellationToken)
        {
            context.Entry(entity.Type).State = EntityState.Modified;
            context.Types.Attach(entity.Type);
            context.Users.Attach(entity.CreatedUser);
            context.Templates.Add(entity);

            await context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }

        /// <summary>
        /// Обновляет существующий шаблон сообщения в базе данных.
        /// </summary>
        /// <param name="entity">Сущность шаблона сообщения с обновленными данными.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        /// <returns>Возвращает <c>true</c>, если обновление прошло успешно.</returns>
        public async Task<bool> UpdateAsync(MessageTemplate entity, CancellationToken cancellationToken)
        {
            context.Entry(entity.Type).State = EntityState.Modified;
            context.Types.Attach(entity.Type);
            context.Entry(entity.CreatedUser).State = EntityState.Unchanged;
            context.Users.Attach(entity.CreatedUser);
            context.Entry(entity.ModifiedUser).State = EntityState.Unchanged;
            context.Users.Attach(entity.ModifiedUser);
            
            context.Templates.Update(entity);

            return await context.SaveChangesAsync(cancellationToken) == 1;
        }

        /// <summary>
        /// Помечает шаблон сообщения как удаленный в базе данных.
        /// </summary>
        /// <param name="entity">Сущность шаблона сообщения с обновленными данными.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        /// <returns>Возвращает <c>true</c>, если удаление прошло успешно.</returns>
        public async Task<bool> DeleteAsync(MessageTemplate entity, CancellationToken cancellationToken)
        {
            return await UpdateAsync(entity, cancellationToken);
        }
    }
}
