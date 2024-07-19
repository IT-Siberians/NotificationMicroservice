namespace NotificationMicroservice.Domain.Interfaces.Model
{
    /// <summary>
    /// Описание модифицируемой Entity 
    /// </summary>
    /// <typeparam name="T"> Тип полей пользователей. </typeparam>
    /// <typeparam name="TKey"> Тип первичного ключа. </typeparam>
    public interface IModifyEntity<T, TKey> : IEntity<TKey>
    {
        /// <summary>
        /// Пользователь создавший запись
        /// </summary>
        T CreateUserName { get; }

        /// <summary>
        /// Пользователь изменивший запись
        /// </summary>
        T? ModifyUserName { get; }

        /// <summary>
        /// Дата и время изменения
        /// </summary>
        DateTime? ModifyDate { get; }
    }
}
