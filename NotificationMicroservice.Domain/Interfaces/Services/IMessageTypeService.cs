using NotificationMicroservice.Domain.Models;

namespace NotificationMicroservice.Domain.Interfaces.Services
{
    public interface IMessageTypeService
    {
        Task<IEnumerable<MessageType>> GetAllAsync();
        Task<MessageType>? GetByIdAsync(Guid id);
        Task<MessageType> AddAsync(MessageType messageType);
        Task<bool> UpdateAsync(MessageType messageType);
        Task<bool> DeleteAsync(Guid id);
    }
}
