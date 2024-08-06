namespace NotificationMicroservice.Domain.Interfaces.Services
{
    public interface IBaseService<TEntity, TEntityCreate, TKey> where TEntity : class where TEntityCreate : class where TKey : struct
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity?> GetByIdAsync(Guid id);
        Task<TKey> AddAsync(TEntityCreate messageTemplate);
    }
}
