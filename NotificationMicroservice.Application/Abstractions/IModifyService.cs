namespace NotificationMicroservice.Application.Abstractions
{
    /// <summary>
    /// Интерфейс для сервисов с возможностью изменения сущностей
    /// </summary>
    /// <typeparam name="TEntity">Сущность</typeparam>
    /// <typeparam name="TEntityCreate">Модель для создания</typeparam>
    /// <typeparam name="TEntityEdit">Модель для изменения</typeparam>
    /// <typeparam name="TKey"></typeparam>
    public interface IModifyService<TEntity, TEntityCreate, TEntityEdit, TKey> : IService<TEntity, TEntityCreate, TKey> where TEntity : class where TEntityCreate : class where TEntityEdit : class where TKey : struct
    {
        /// <summary>
        /// Изменение сущности
        /// </summary>
        /// <param name="messageTemplate">Модель для изменения</param>
        /// <returns>Булевое значение</returns>
        Task<bool> UpdateAsync(TEntityEdit messageTemplate);

        /// <summary>
        /// Мягкое удаление сущности
        /// </summary>
        /// <param name="messageTemplate">Модель для изменения</param>
        /// <returns>Булевое значение</returns>
        Task<bool> DeleteAsync(TEntityEdit messageTemplate);
    }
}
