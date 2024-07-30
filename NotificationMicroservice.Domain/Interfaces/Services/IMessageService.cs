﻿using NotificationMicroservice.Domain.Models;

namespace NotificationMicroservice.Domain.Interfaces.Services
{
    /// <summary>
    /// Описание методов для сервиса Сообшений (чтение)
    /// </summary>
    public interface IMessageService
    {
        /// <summary>
        /// Получение всех сообщений
        /// </summary>
        /// <returns>Коллекция сущностей Сообщей</returns>
        Task<IEnumerable<Message>> GetAllAsync();

        /// <summary>
        /// Получение сообщения по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор сущности</param>
        /// <returns>Сущность Сообщение</returns>
        Task<Message>? GetByIdAsync(Guid id);
    }
}
