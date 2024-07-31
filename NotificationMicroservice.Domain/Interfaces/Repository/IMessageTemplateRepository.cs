namespace NotificationMicroservice.Domain.Interfaces.Repository
{
    /// <summary>
    /// Описания методов для репозитория Шаблонов сообщений.
    /// </summary>
    /// <typeparam name="TEntity"> Тип Entity для репозитория. </typeparam>
    /// <typeparam name="TKey"> Тип первичного ключа. </typeparam>
    public interface IMessageTemplateRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey>
    {
        /// <summary>
        /// Добавить в базу одну сущность.
        /// </summary>
        /// <param name="entity"> Сущность для добавления. </param>
        /// <param name="cancellationToken"> Токен отмены. </param>
        /// <returns> Добавленная сущность. </returns>
        Task<TKey> AddAsync(TEntity entity, CancellationToken cancellationToken);

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
