namespace NotificationMicroservice.Domain.Interfaces.Repository
{
    /// <summary>
    /// Описания методов для репозитория Сообщений.
    /// </summary>
    /// <typeparam name="TEntity"> Тип Entity для репозитория. </typeparam>
    /// <typeparam name="TKey"> Тип первичного ключа. </typeparam>
    public interface IMessageRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey>
    {
        /// <summary>
        /// Добавить в базу одну сущность.
        /// </summary>
        /// <param name="entity"> Сущность для добавления. </param>
        /// <param name="cancellationToken"> Токен отмены. </param>
        /// <returns> Добавленная сущность. </returns>
        Task<Guid> AddAsync(TEntity entity, CancellationToken cancellationToken);
    }
}
