using NotificationMicroservice.Domain.Entity;

namespace NotificationMicroservice.Domain.Interfaces.Repository
{
    /// <summary>
    /// Описания методов для репозитория Шаблонов сообщений.
    /// </summary>
    public interface IMessageTemplateRepository : IBaseRepository<MessageTemplate, Guid>
    {
        /// <summary>
        /// Добавить в базу одну сущность.
        /// </summary>
        /// <param name="entity"> Сущность для добавления. </param>
        /// <param name="cancellationToken"> Токен отмены. </param>
        /// <returns> Добавленная сущность. </returns>
        Task<Guid> AddAsync(MessageTemplate entity, CancellationToken cancellationToken);

        /// <summary>
        /// Для сущности проставить состояние - что она изменена.
        /// </summary>
        /// <param name="entity"> Сущность для изменения. </param>
        /// <param name="cancellationToken"> Токен отмены. </param>
        /// <returns> Была ли сущность обновлена. </returns>
        Task<bool> UpdateAsync(MessageTemplate entity, CancellationToken cancellationToken);

        /// <summary>
        /// Удалить сущность.
        /// </summary>
        /// <param name="entity"> Сущность для изменения. </param>
        /// <param name="cancellationToken"> Токен отмены. </param>
        /// <returns> Была ли сущность удалена. </returns>
        Task<bool> DeleteAsync(MessageTemplate entity, CancellationToken cancellationToken);
    }
}
