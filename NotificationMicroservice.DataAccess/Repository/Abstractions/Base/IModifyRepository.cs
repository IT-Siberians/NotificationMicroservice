using NotificationMicroservice.Domain.Entities.Base;

namespace NotificationMicroservice.DataAccess.Repository.Abstractions.Base
{
    public interface IModifyRepository<TEntity, TKey> : IRepository<TEntity, TKey>
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
