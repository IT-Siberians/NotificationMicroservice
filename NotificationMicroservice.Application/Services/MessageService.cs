using AutoMapper;
using NotificationMicroservice.Application.Abstractions;
using NotificationMicroservice.Application.Model.Message;
using NotificationMicroservice.DataAccess.Repository.Abstractions;
using NotificationMicroservice.Domain.Entities;
using NotificationMicroservice.Domain.ValueObjects;

namespace NotificationMicroservice.Application.Services
{
    public class MessageService(IMessageRepository messageRepository, IMessageTypeRepository typeRepository, IMapper mapper) : IMessageApplicationService
    {
        public async Task<Guid?> AddAsync(CreateMessageModel messageCreate, CancellationToken cancellationToken = default)
        {
            var type = await typeRepository.GetByIdAsync(messageCreate.MessageTypeId, cancellationToken);

            if (type is null)
            {
                return null;
            }

            var message = new Message(type, new MessageText(messageCreate.MessageText), messageCreate.Direction, DateTime.UtcNow);

            return await messageRepository.AddAsync(message, cancellationToken);
        }

        public async Task<IEnumerable<MessageModel>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var dbEntities = await messageRepository.GetAllAsync(cancellationToken, true);

            return dbEntities.Select(mapper.Map<MessageModel>);
        }

        public async Task<MessageModel?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var dbEntity = await messageRepository.GetByIdAsync(id, cancellationToken);

            return dbEntity is null ? null : mapper.Map<MessageModel>(dbEntity);
        }
    }
}
