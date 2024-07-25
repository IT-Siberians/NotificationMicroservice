﻿namespace NotificationMicroservice.Domain.Interfaces.Model
{
    /// <summary>
    /// Описание базовой Entity 
    /// </summary>
    /// <typeparam name="TKey"> Тип первичного ключа. </typeparam>
    public interface IEntity<Tkey>
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        Tkey Id { get; }

        /// <summary>
        /// Дата и время создания
        /// </summary>
        DateTime CreateDate { get; }
    }
}
