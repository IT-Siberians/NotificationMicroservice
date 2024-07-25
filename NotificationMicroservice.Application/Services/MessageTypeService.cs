using NotificationMicroservice.Domain.Interfaces.Repository;
using NotificationMicroservice.Domain.Interfaces.Services;
using NotificationMicroservice.Domain.Models;

namespace NotificationMicroservice.Application.Services
{
    public class MessageTypeService : IMessageTypeService
    {
        private readonly IMessageTypeRepository _messageTypeRepository;
        private readonly CancellationTokenSource cancelTokenSource = new CancellationTokenSource();

        public MessageTypeService(IMessageTypeRepository messageTypeRepository)
        {
            _messageTypeRepository = messageTypeRepository;
        }

        public async Task<IEnumerable<MessageType>> GetAllAsync()
        {
            return await _messageTypeRepository.GetAllAsync(cancelTokenSource.Token, true);
        }

        public async Task<MessageType>? GetByIdAsync(Guid id)
        {
            return await _messageTypeRepository.GetByIdAsync(id, cancelTokenSource.Token);
        }
        public async Task<Guid> AddAsync(MessageType messageType)
        {
            return await _messageTypeRepository.AddAsync(messageType, cancelTokenSource.Token);
        }

        public async Task<bool> UpdateAsync(MessageType messageType)
        {
            return await _messageTypeRepository.UpdateAsync(messageType, cancelTokenSource.Token);
        }

        public async Task<bool> DeleteAsync(MessageType messageType)
        {
            return await _messageTypeRepository.DeleteAsync(messageType, cancelTokenSource.Token);
        }
    }
}
