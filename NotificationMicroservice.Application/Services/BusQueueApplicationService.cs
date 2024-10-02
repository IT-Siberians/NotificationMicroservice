using AutoMapper;
using NotificationMicroservice.Application.Model.BusQueue;
using NotificationMicroservice.Application.Services.Abstractions;
using NotificationMicroservice.DataAccess.Models;
using NotificationMicroservice.DataAccess.Repository.Abstractions;
using NotificationMicroservice.DataAccess.ValueObject;

namespace NotificationMicroservice.Application.Services
{
    public class BusQueueApplicationService(IBusQueueRepository queueRepository, IMessageTypeRepository typeRepository, IUserRepository userRepository, IMapper mapper) : IBusQueueApplicationService
    {
        public async Task<IEnumerable<BusQueueModel>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var dbEntities = await queueRepository.GetAllAsync(cancellationToken);

            return dbEntities.Select(mapper.Map<BusQueueModel>);
        }

        public async Task<BusQueueModel?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var dbEntity = await queueRepository.GetByIdAsync(id, cancellationToken);

            return dbEntity is null ? null : mapper.Map<BusQueueModel>(dbEntity);
        }

        public async Task<BusQueueModel?> GetTypeByEventAsync(string queueName, CancellationToken cancellationToken = default)
        {
            var dbEntity = await queueRepository.GetTypeByEventAsync(new QueueName(queueName), cancellationToken);

            return dbEntity is null ? null : mapper.Map<BusQueueModel>(dbEntity);
        }

        public async Task<Guid?> AddAsync(CreateBusQueueModel queue, CancellationToken cancellationToken = default)
        {
            var type = await typeRepository.GetByIdAsync(queue.MessageTypeId, cancellationToken);

            if (type is null)
            {
                return null;
            }

            var user = await userRepository.GetByIdAsync(queue.CreatedByUserId, cancellationToken);

            if (user is null)
            {
                return null;
            }

            var busQueue = new BusQueue(new QueueName(queue.QueueName), type, false, user, DateTime.UtcNow, null, null);

            return await queueRepository.AddAsync(busQueue, cancellationToken);

        }

        public async Task<bool> UpdateAsync(UpdateBusQueueModel queue, CancellationToken cancellationToken = default)
        {
            var type = await typeRepository.GetByIdAsync(queue.MessageTypeId, cancellationToken);

            if (type is null)
            {
                return false;
            }

            var user = await userRepository.GetByIdAsync(queue.ModifiedByUserId, cancellationToken);

            if (user is null)
            {
                return false;
            }

            var busQueue = await queueRepository.GetByIdAsync(queue.Id, cancellationToken);

            if (busQueue is null)
            {
                return false;
            }

            busQueue.Update(type, queue.IsRemoved, user, DateTime.UtcNow);

            return await queueRepository.UpdateAsync(busQueue, cancellationToken);

        }

        public async Task<bool> DeleteAsync(DeleteBusQueueModel queue, CancellationToken cancellationToken = default)
        {
            var user = await userRepository.GetByIdAsync(queue.ModifiedByUserId, cancellationToken);

            if (user is null)
            {
                return false;
            }

            var busQueue = await queueRepository.GetByIdAsync(queue.Id, cancellationToken);

            if (busQueue is null)
            {
                return false;
            }

            busQueue.Delete(user, DateTime.UtcNow);

            return await queueRepository.DeleteAsync(busQueue, cancellationToken);
        }
    }
}
