namespace NotificationMicroservice.Domain.Entities.Base
{
    /// <summary>
    /// Описание модифицируемой Entity 
    /// </summary>
    /// <typeparam name="TEntity"> Тип полей пользователей. </typeparam>
    /// <typeparam name="TKey"> Тип первичного ключа. </typeparam>
    public interface IModifyEntity<TEntity, out TKey> : IEntity<TKey>
        where TEntity : class
        where TKey : struct
    {
        /// <summary>
        /// Пользователь создавший запись
        /// </summary>
        TEntity CreatedByUser { get; }

        /// <summary>
        /// Пользователь изменивший запись
        /// </summary>
        TEntity? ModifiedByUser { get; }

        /// <summary>
        /// Дата и время изменения
        /// </summary>
        DateTime? ModificationDate { get; }
    }
}
