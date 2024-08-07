using Microsoft.EntityFrameworkCore;
using NotificationMicroservice.Domain.Entity;
using NotificationMicroservice.Domain.Interfaces.Repository;

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
            _context.Types.Attach(entity.Type);
            await _context.Messages.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity.Id;
        }

        public async Task<IEnumerable<Message>> GetAllAsync(CancellationToken cancellationToken, bool asNoTracking = false)
        {
            return await (asNoTracking ? _context.Messages.AsNoTracking() : _context.Messages)
                .ToListAsync(cancellationToken);
        }

        public async Task<Message?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _context.Messages
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync(cancellationToken);
        }
    }
}
