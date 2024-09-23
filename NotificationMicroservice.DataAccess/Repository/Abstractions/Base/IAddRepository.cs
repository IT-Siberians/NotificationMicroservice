using NotificationMicroservice.Domain.Entities.Base;

namespace NotificationMicroservice.DataAccess.Repository.Abstractions.Base
{
    /// <summary>
    /// Представляет абстракцию репозитория для получения, добавления сущностей в базу данных.
    /// </summary>
    /// <typeparam name="TEntity">Тип сущности, с которой работает репозиторий.</typeparam>
    /// <typeparam name="TKey">Тип ключа сущности, обычно первичного ключа.</typeparam>
    public interface IAddRepository<TEntity, TKey> : IRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
        where TKey : struct
    {
        /// <summary>
        /// Добавить в базу одну сущность.
        /// </summary>
        /// <param name="entity"> Сущность для добавления. </param>
        /// <param name="cancellationToken"> Токен отмены. </param>
        /// <returns> Добавленная сущность. </returns>
        Task<TKey> AddAsync(TEntity entity, CancellationToken cancellationToken);
    }
}
