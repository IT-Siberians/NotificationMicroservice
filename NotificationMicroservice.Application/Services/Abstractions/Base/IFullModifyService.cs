using NotificationMicroservice.Application.Model.Abstractions;

namespace NotificationMicroservice.Application.Services.Abstractions.Base
{
    /// <summary>
    /// Интерфейс для сервисов с возможностью изменения сущностей
    /// </summary>
    /// <typeparam name="TEntity">Сущность</typeparam>
    /// <typeparam name="TEntityCreate">Модель для создания</typeparam>
    /// <typeparam name="TEntityUpdate">Модель для изменения</typeparam>
    /// <typeparam name="TEntityDelete">Модель для удаления</typeparam>
    /// <typeparam name="TKey"></typeparam>
    public interface IFullModifyService<TEntity, TEntityCreate, TEntityUpdate, TEntityDelete, TKey> : IUpdateService<TEntity, TEntityCreate, TEntityUpdate, TKey>
        where TEntity : class, IBaseModel<TKey>
        where TEntityCreate : class, ICreateModel
        where TEntityUpdate : class, IBaseModel<TKey>
        where TKey : struct
    {
        /// <summary>
        /// Мягкое удаление сущности
        /// </summary>
        /// <param name="entity">Модель для изменения</param>
        /// <returns>Булевое значение</returns>
        Task<bool> DeleteAsync(TEntityDelete entity, CancellationToken cancellationToken);
    }
}
