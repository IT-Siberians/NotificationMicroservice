namespace NotificationMicroservice.Domain.Entities.Base
{
    /// <summary>
    /// Описание модифицируемой Entity 
    /// </summary>
    /// <typeparam name="TKey"> Тип первичного ключа. </typeparam>
    public interface IModifyEntity<out TKey> : IEntity<TKey>
        where TKey : struct
    {
        /// <summary>
        /// Пользователь создавший запись
        /// </summary>
        User CreatedByUser { get; }

        /// <summary>
        /// Пользователь изменивший запись
        /// </summary>
        User? ModifiedByUser { get; }

        /// <summary>
        /// Дата и время изменения
        /// </summary>
        DateTime? ModificationDate { get; }
    }
}
