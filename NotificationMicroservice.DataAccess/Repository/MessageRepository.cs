using Microsoft.EntityFrameworkCore;
using NotificationMicroservice.DataAccess.Entities;
using NotificationMicroservice.Domain.Interfaces.Repository;

namespace NotificationMicroservice.DataAccess.Repository
{
    public class MessageRepository : IMessageRepository<MessageEntity, Guid>
    {
        private readonly NotificationMicroserviceDbContext _context;

        public MessageRepository(NotificationMicroserviceDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> AddAsync(MessageEntity entity, CancellationToken cancellationToken)
        {
            //var messageEntity = new MessageEntity()
            //{
            //    Id = entity.Id,
            //    TypeId = entity.MessageType.Id,
            //    MessageText = entity.MessageText,
            //    Direction = entity.Direction,
            //    CreateDate = entity.CreateDate,
            //};
            await _context.Messages.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity.Id;
        }

        public async Task<IEnumerable<MessageEntity>> GetAllAsync(CancellationToken cancellationToken, bool asNoTracking = false)
        {
            return await (asNoTracking ? _context.Messages.AsNoTracking() : _context.Messages)
                .ToListAsync(cancellationToken);
        }

        public async Task<MessageEntity>? GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _context.Messages
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync(cancellationToken);
        }
    }
}
