using NotificationMicroservice.Domain.Models;

namespace NotificationMicroservice.Domain.Interfaces.Services
{
    public interface IMessageTemplateService
    {
        Task<IEnumerable<MessageTemplate>> GetAllAsync();
        Task<MessageTemplate>? GetByIdAsync(Guid id);
        Task<Guid> AddAsync(MessageTemplate messageTemplate);
        Task<bool> UpdateAsync(MessageTemplate messageTemplate);
        Task<bool> DeleteAsync(MessageTemplate messageTemplate);
    }
}
