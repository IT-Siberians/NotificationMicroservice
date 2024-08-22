namespace NotificationMicroservice.Application.Abstractions.Base
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TEntityCreate"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    public interface IService<TEntity, TEntityCreate, TKey> where TEntity : class where TEntityCreate : class where TKey : struct
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> GetAllAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<TEntity?> GetByIdAsync(Guid id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageTemplate"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<TKey?> AddAsync(TEntityCreate messageTemplate);
    }
}
