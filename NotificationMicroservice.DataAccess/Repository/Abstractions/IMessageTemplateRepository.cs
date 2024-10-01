using NotificationMicroservice.DataAccess.Repository.Abstractions.Base;
using NotificationMicroservice.Domain.Entities;
using NotificationMicroservice.Domain.Enums;

namespace NotificationMicroservice.DataAccess.Repository.Abstractions
{
    /// <summary>
    /// Интерфейс репозитория для управления объектами типа <see cref="MessageTemplate"/>.
    /// Этот интерфейс расширяет функциональность базового интерфейса <see cref="IModifyRepository{T, TKey}"/> 
    /// и добавляет методы для получения шаблонов сообщений по типу и по имени очереди и языку.
    /// </summary>
    public interface IMessageTemplateRepository : IModifyRepository<MessageTemplate, Guid>
    {
        /// <summary>
        /// Возвращает коллекцию шаблонов сообщений, соответствующих указанному типу.
        /// </summary>
        /// <param name="id">Идентификатор типа</param>
        /// <param name="cancellationToken">Маркер отмены</param>
        /// <returns>Коллекция шаблонов сообщений</returns>
        Task<IEnumerable<MessageTemplate>> GetByTypeIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Возвращает шаблон сообщения, соответствующий указанной очереди и языку.
        /// </summary>
        /// <param name="id">Идентификатор очереди</param>
        /// <param name="language">Язык шаблона сообщения</param>
        /// <param name="cancellationToken">Маркер отмены</param>
        /// <returns>Шаблон сообщения или null, если не найден</returns>
        Task<MessageTemplate?> GetByQueueAndLanguageAsync(Guid id, Language language, CancellationToken cancellationToken);
    }
}
