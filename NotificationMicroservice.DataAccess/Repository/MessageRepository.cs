using Microsoft.EntityFrameworkCore;
using NotificationMicroservice.DataAccess.Entities;
using NotificationMicroservice.Domain.Interfaces.Repository;
using NotificationMicroservice.Domain.Models;

namespace NotificationMicroservice.DataAccess.Repository
{
    public class MessageRepository : IMessageRepository
    {
        private readonly NotificationMicroserviceDbContext _context;

        public MessageRepository(NotificationMicroserviceDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> AddAsync(Message entity, CancellationToken cancellationToken)
        {
            var messageEntity = new MessageEntity()
            {
                Id = entity.Id,
                TypeId = entity.MessageType.Id,
                MessageText = entity.MessageText,
                Direction = entity.Direction,
                CreateDate = entity.CreateDate,
            };
            await _context.Messages.AddAsync(messageEntity);
            await _context.SaveChangesAsync();

            return entity.Id;
        }

        public async Task<IEnumerable<Message>> GetAllAsync(CancellationToken cancellationToken, bool asNoTracking = false)
        {
            return await (asNoTracking ? _context.Messages.AsNoTracking() : _context.Messages)
                .Select(z => new Message(
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
                    z.CreateDate))
                .ToListAsync(cancellationToken);
        }

        public async Task<Message>? GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _context.Messages
                .Where(x => x.Id == id)
                .Select(z => new Message(
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
                    z.CreateDate))
                .FirstAsync(cancellationToken);
        }
    }
}
