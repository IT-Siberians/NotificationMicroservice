using NotificationMicroservice.Domain.Models;

namespace NotificationMicroservice.Domain.Interfaces.Services
{
    public interface IMessageService
    {
        Task<IEnumerable<Message>> GetAllAsync();
        Task<Message>? GetByIdAsync(Guid id);
    }
}
