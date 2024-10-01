using NotificationMicroservice.Application.Model.Abstractions;

namespace NotificationMicroservice.Application.Services.Abstractions.Base
{
    public interface IUpdateService<TEntity, TEntityCreate, TEntityUpdate, TKey> : IService<TEntity, TEntityCreate, TKey>
        where TEntity : class, IBaseModel<TKey>
        where TEntityCreate : class, ICreateModel
        where TEntityUpdate : class, IBaseModel<TKey>
        where TKey : struct, IEquatable<TKey>
    {
        /// <summary>
        /// Изменение сущности
        /// </summary>
        /// <param name="entity">Модель для изменения</param>
        /// <returns>Булевое значение</returns>
        Task<bool> UpdateAsync(TEntityUpdate entity, CancellationToken cancellationToken);
    }
}
