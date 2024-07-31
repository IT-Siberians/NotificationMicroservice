using NotificationMicroservice.DataAccess.Entities;
using NotificationMicroservice.Domain.Interfaces.Repository;
using NotificationMicroservice.Domain.Interfaces.Services;
using NotificationMicroservice.Domain.Models;

namespace NotificationMicroservice.Application.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository<MessageEntity, Guid> _messageRepository;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

        public MessageService(IMessageRepository<MessageEntity, Guid> messageRepository)
        {
            _messageRepository = messageRepository;
        }
        public async Task<IEnumerable<Message>> GetAllAsync()
        {
            var entitiesDb = await _messageRepository.GetAllAsync(_cancellationTokenSource.Token, true);
            return entitiesDb.Select(z => new Message(
                                z.Id,
                                new MessageType(
                                    z.Type.Id,
                                    z.Type.Name,
                                    z.Type.IsRemove,
                                    z.Type.CreateUserName,
                                    z.Type.CreateDate,
                                    z.Type.ModifyUserName,
                                    z.Type.ModifyDate),
                                z.MessageText,
                                z.Direction,
                                z.CreateDate));
        }

        public async Task<Message>? GetByIdAsync(Guid id)
        {
            var entityDb = await _messageRepository.GetByIdAsync(id, _cancellationTokenSource.Token);
            
            if(entityDb == null)
            {
                throw new InvalidOperationException("!!!ALARM!!!");
            }

            return new Message(
                    entityDb.Id,
                    new MessageType(
                        entityDb.Type.Id,
                        entityDb.Type.Name,
                        entityDb.Type.IsRemove,
                        entityDb.Type.CreateUserName,
                        entityDb.Type.CreateDate,
                        entityDb.Type.ModifyUserName,
                        entityDb.Type.ModifyDate),
                    entityDb.MessageText,
                    entityDb.Direction,
                    entityDb.CreateDate);
        }
    }
}
