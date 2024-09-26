using AutoMapper;
using NotificationMicroservice.Application.Abstractions;
using NotificationMicroservice.Application.Model.Message;
using NotificationMicroservice.DataAccess.Repository.Abstractions;
using NotificationMicroservice.Domain.Entities;

namespace NotificationMicroservice.Application.Services
{
    public class MessageService(IMessageRepository messageRepository, IMessageTypeRepository typeRepository, IMapper mapper) : IMessageApplicationService
    {
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

        public async Task<Guid?> AddAsync(CreateMessageModel messageCreate)
        {
            var type = await typeRepository.GetByIdAsync(messageCreate.MessageTypeId, _cancellationTokenSource.Token);

            if (type is null)
            {
                return null;
            }

            var message = new Message(type, messageCreate.MessageText, messageCreate.Direction, DateTime.UtcNow);

            return await messageRepository.AddAsync(message, _cancellationTokenSource.Token);
        }

        public async Task<IEnumerable<MessageModel>> GetAllAsync()
        {
            var dbEntities = await messageRepository.GetAllAsync(_cancellationTokenSource.Token, true);

            return dbEntities.Select(mapper.Map<MessageModel>);
        }

        public async Task<MessageModel?> GetByIdAsync(Guid id)
        {
            var dbEntity = await messageRepository.GetByIdAsync(id, _cancellationTokenSource.Token);

            return dbEntity is null ? null : mapper.Map<MessageModel>(dbEntity);
        }
    }
}
