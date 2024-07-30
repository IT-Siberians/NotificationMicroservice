using NotificationMicroservice.Domain.Models;

namespace NotificationMicroservice.Domain.Interfaces.Repository
{
    /// <summary>
    /// Описания методов для репозитория Типов сообщений.
    /// </summary>
    public interface IMessageTypeRepository<TEntity> : IBaseRepository<TEntity, Guid>
    {
        /// <summary>
        /// Добавить в базу одну сущность.
        /// </summary>
        /// <param name="entity"> Сущность для добавления. </param>
        /// <param name="cancellationToken"> Токен отмены. </param>
        /// <returns> Добавленная сущность. </returns>
        Task<Guid> AddAsync(TEntity entity, CancellationToken cancellationToken);

        /// <summary>
        /// Для сущности проставить состояние - что она изменена.
        /// </summary>
        /// <param name="entity"> Сущность для изменения. </param>
        /// <param name="cancellationToken"> Токен отмены. </param>
        /// <returns> Была ли сущность обновлена. </returns>
        Task<bool> UpdateAsync(TEntity entity, CancellationToken cancellationToken);

        /// <summary>
        /// Удалить сущность.
        /// </summary>
        /// <param name="entity"> Сущность для изменения. </param>
        /// <param name="cancellationToken"> Токен отмены. </param>
        /// <returns> Была ли сущность удалена. </returns>
        Task<bool> DeleteAsync(TEntity entity, CancellationToken cancellationToken);
    }
}
