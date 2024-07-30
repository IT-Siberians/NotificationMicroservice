using NotificationMicroservice.Domain.Models;

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
        Task<IEnumerable<MessageTemplate>> GetAllAsync();

        /// <summary>
        /// Получение сущности Шаблона по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор Шаблона</param>
        /// <returns>Шаблон</returns>
        Task<MessageTemplate>? GetByIdAsync(Guid id);

        /// <summary>
        /// Добавление Шаблона сообщений
        /// </summary>
        /// <param name="messageTemplate">Сущность</param>
        /// <returns>Идентификатор сущности</returns>
        Task<Guid> AddAsync(MessageTemplate messageTemplate);

        /// <summary>
        /// Обновление сущности Шаблона
        /// </summary>
        /// <param name="messageTemplate">Сущность</param>
        /// <returns>Булевое значение</returns>
        Task<bool> UpdateAsync(MessageTemplate messageTemplate);

        /// <summary>
        /// Мягкое удаление Шаблона сообщений
        /// </summary>
        /// <param name="messageTemplate">Сущность</param>
        /// <returns>Булевое значение</returns>
        Task<bool> DeleteAsync(MessageTemplate messageTemplate);
    }
}
