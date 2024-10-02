using NotificationMicroservice.DataAccess.Models;
using NotificationMicroservice.DataAccess.Repository.Abstractions.Base;
using NotificationMicroservice.DataAccess.ValueObject;

namespace NotificationMicroservice.DataAccess.Repository.Abstractions
{
    /// <summary>
    /// Интерфейс репозитория для работы с очередями шины <see cref="BusQueue"/>.
    /// </summary>
    public interface IBusQueueRepository : IModifyRepository<BusQueue, Guid>
    {
        /// <summary>
        /// Получение типа события по очереди шины 
        /// </summary>
        /// <param name="queueName">Тип события</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Очередь шины или null, если не найдена</returns>
        Task<BusQueue?> GetTypeByEventAsync(QueueName queueName, CancellationToken cancellationToken);
    }
}
