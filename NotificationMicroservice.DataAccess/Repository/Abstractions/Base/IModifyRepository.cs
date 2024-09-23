using NotificationMicroservice.Domain.Entities.Base;

namespace NotificationMicroservice.DataAccess.Repository.Abstractions.Base
{
    /// <summary>
    /// Представляет абстракцию репозитория для получения, добавления и модификации сущностей в базе данных.
    /// </summary>
    /// <typeparam name="TEntity">Тип сущности, с которой работает репозиторий.</typeparam>
    /// <typeparam name="TKey">Тип ключа сущности, обычно первичного ключа.</typeparam>
    public interface IModifyRepository<TEntity, TKey> : IAddRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
        where TKey : struct
    {
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
