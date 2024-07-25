using NotificationMicroservice.Domain.Interfaces.Repository;
using NotificationMicroservice.Domain.Interfaces.Services;
using NotificationMicroservice.Domain.Models;

namespace NotificationMicroservice.Application.Services
{
    public class MessageTemplateService : IMessageTemplateService
    {
        private readonly IMessageTemplateRepository _messageTemplateRepository;
        private readonly CancellationTokenSource _cancelTokenSource = new CancellationTokenSource();

        public MessageTemplateService(IMessageTemplateRepository messageTemplateRepository)
        {
            _messageTemplateRepository = messageTemplateRepository;
        }
        public async Task<Guid> AddAsync(MessageTemplate messageTemplate)
        {
            return await _messageTemplateRepository.AddAsync(messageTemplate, _cancelTokenSource.Token);
        }

        public async Task<bool> DeleteAsync(MessageTemplate messageTemplate)
        {
            return await _messageTemplateRepository.DeleteAsync(messageTemplate, _cancelTokenSource.Token);
        }

        public async Task<IEnumerable<MessageTemplate>> GetAllAsync()
        {
            return await _messageTemplateRepository.GetAllAsync(_cancelTokenSource.Token, true);
        }

        public async Task<MessageTemplate>? GetByIdAsync(Guid id)
        {
            return await _messageTemplateRepository.GetByIdAsync(id, _cancelTokenSource.Token);
        }

        public async Task<bool> UpdateAsync(MessageTemplate messageTemplate)
        {
            return await _messageTemplateRepository.UpdateAsync(messageTemplate, _cancelTokenSource.Token);
        }
    }
}
