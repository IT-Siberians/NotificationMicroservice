using NotificationMicroservice.Domain.Interfaces.Repository;
using NotificationMicroservice.Domain.Interfaces.Services;
using NotificationMicroservice.Domain.Models;

namespace NotificationMicroservice.Application.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

        public MessageService(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }
        public async Task<IEnumerable<Message>> GetAllAsync()
        {
            return await _messageRepository.GetAllAsync(_cancellationTokenSource.Token, true);
        }

        public async Task<Message>? GetByIdAsync(Guid id)
        {
            return await _messageRepository.GetByIdAsync(id, _cancellationTokenSource.Token);
        }
    }
}
