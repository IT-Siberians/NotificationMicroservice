using NotificationMicroservice.Application.Model.BusQueue;
using NotificationMicroservice.Application.Services.Abstractions.Base;
using NotificationMicroservice.Domain.ValueObjects;

namespace NotificationMicroservice.Application.Services.Abstractions
{
    /// <summary>
    /// Интерефейс для сервиса работы с очередями сообщений
    /// </summary>
    public interface IBusQueueApplicationService : IFullModifyService<BusQueueModel, CreateBusQueueModel, UpdateBusQueueModel, DeleteBusQueueModel, Guid>
    {
        /// <summary>
        /// Получние типа по имени очереди сообщений
        /// </summary>
        /// <param name="queueName"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<BusQueueModel?> GetTypeByEventAsync(QueueName queueName, CancellationToken cancellationToken);
    }
}
