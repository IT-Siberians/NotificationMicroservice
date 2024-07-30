using NotificationMicroservice.Domain.Models;

namespace NotificationMicroservice.Domain.Interfaces.Services
{
    /// <summary>
    /// Описание основных методов для сервиса Типов сообщений
    /// </summary>
    public interface IMessageTypeService
    {
        /// <summary>
        /// Получение всех сущностей Типа сообщений
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<MessageType>> GetAllAsync();

        /// <summary>
        /// Получение сущности Типа сообщений по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор сущности</param>
        /// <returns>Сущность</returns>
        Task<MessageType>? GetByIdAsync(Guid id);

        /// <summary>
        /// Добавление Типа сообщений
        /// </summary>
        /// <param name="messageType">Сущность</param>
        /// <returns>Идентификатор сущности</returns>
        Task<Guid> AddAsync(MessageType messageType);

        /// <summary>
        /// Обновление сущности Типа сообщений
        /// </summary>
        /// <param name="messageType">Сущность</param>
        /// <returns>Булевое значение</returns>
        Task<bool> UpdateAsync(MessageType messageType);

        /// <summary>
        /// Мягкое удаление сущности Типа сообщений
        /// </summary>
        /// <param name="messageType">Сущность</param>
        /// <returns>Булевое значение</returns>
        Task<bool> DeleteAsync(MessageType messageType);
    }
}
