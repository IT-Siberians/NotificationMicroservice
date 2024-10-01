using NotificationMicroservice.Application.Model.Abstractions;

namespace NotificationMicroservice.Application.Services.Abstractions.Base
{
    /// <summary>
    /// Интерфейс для сервисов, обеспечивающих базовые операции с сущностями.
    /// </summary>
    /// <typeparam name="TEntity">Тип сущности, с которой производится работа.</typeparam>
    /// <typeparam name="TEntityCreate">Тип сущности, используемый для создания новых записей.</typeparam>
    /// <typeparam name="TKey">Тип ключа сущности.</typeparam>
    public interface IService<TEntity, TEntityCreate, TKey>
        where TEntity : class, IBaseModel<TKey>
        where TEntityCreate : class, ICreateModel
        where TKey : struct, IEquatable<TKey>
    {
        /// <summary>
        /// Получает все сущности из источника данных.
        /// </summary>
        /// <returns>Список всех сущностей типа <typeparamref name="TEntity"/>.</returns>
        Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получает сущность по её идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор сущности.</param>
        /// <returns>Сущность типа <typeparamref name="TEntity"/> с указанным идентификатором или <c>null</c>, если сущность не найдена.</returns>
        Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Добавляет новую сущность в источник данных.
        /// </summary>
        /// <param name="entity">Сущность, используемая для создания новой записи.</param>
        /// <returns>Идентификатор новой сущности типа <typeparamref name="TKey"/>.</returns>
        Task<TKey?> AddAsync(TEntityCreate entity, CancellationToken cancellationToken);
    }
}
