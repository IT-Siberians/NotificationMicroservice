using NotificationMicroservice.Application.Model;

namespace NotificationMicroservice.Application.Services.Abstractions.Base
{
    public interface IUpdateService<TEntity, TEntityCreate, TEntityUpdate, TKey> : IService<TEntity, TEntityCreate, TKey>
        where TEntity : class, IBaseModel<TKey>
        where TEntityCreate : class
        where TEntityUpdate : class, IBaseModel<TKey>
        where TKey : struct
    {
        /// <summary>
        /// Изменение сущности
        /// </summary>
        /// <param name="entity">Модель для изменения</param>
        /// <returns>Булевое значение</returns>
        Task<bool> UpdateAsync(TEntityUpdate entity);
    }
}
