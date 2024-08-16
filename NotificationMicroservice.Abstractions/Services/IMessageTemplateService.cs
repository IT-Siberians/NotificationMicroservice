using NotificationMicroservice.Domain.Entities;

namespace NotificationMicroservice.Domain.Interfaces.Services
{
    /// <summary>
    /// Описание методов для сервиса Шаблонов сообщений
    /// </summary>
    public interface IMessageTemplateService
    {
        /// <summary>
        /// Получение всех сущностей Шаблонов
        /// </summary>
        /// <returns>Коллекция сущностей Шаблонов</returns>
        Task<IEnumerable<MessageTemplate>> GetAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получение сущности Шаблона по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор Шаблона</param>
        /// <returns>Шаблон</returns>
        Task<MessageTemplate>? GetByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Добавление Шаблона сообщений
        /// </summary>
        /// <param name="messageTemplate">Сущность</param>
        /// <returns>Идентификатор сущности</returns>
        Task<Guid> AddAsync(MessageTemplate messageTemplate, CancellationToken cancellationToken);

        /// <summary>
        /// Обновление сущности Шаблона
        /// </summary>
        /// <param name="messageTemplate">Сущность</param>
        /// <returns>Булевое значение</returns>
        Task<bool> UpdateAsync(MessageTemplate messageTemplate, CancellationToken cancellationToken);

        /// <summary>
        /// Мягкое удаление Шаблона сообщений
        /// </summary>
        /// <param name="messageTemplate">Сущность</param>
        /// <returns>Булевое значение</returns>
        Task<bool> DeleteAsync(MessageTemplate messageTemplate, CancellationToken cancellationToken);
    }
}
