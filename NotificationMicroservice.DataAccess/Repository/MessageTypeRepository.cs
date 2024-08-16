using Microsoft.EntityFrameworkCore;
using NotificationMicroservice.DataAccess.Interfaces;
using NotificationMicroservice.Domain.Entities;

namespace NotificationMicroservice.DataAccess.Repository
{
    public class MessageTypeRepository : IMessageTypeRepository
    {
        private readonly NotificationMicroserviceDbContext _context;

        public MessageTypeRepository(NotificationMicroserviceDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Запросить все типы сообщений из базы
        /// </summary>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <param name="asNoTracking">Вызвать с AsNoTracking</param>
        /// <returns>Список сущностей</returns>
        public async Task<IEnumerable<MessageType>> GetAllAsync(CancellationToken cancellationToken, bool asNoTracking = false)
        {
            return await (asNoTracking ? _context.Types.AsNoTracking() : _context.Types)
                .ToListAsync(cancellationToken);

        }

        public async Task<MessageType?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _context.Types
                .Where(x => x.Id == id)
                .AsNoTracking()
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<Guid> AddAsync(MessageType entity, CancellationToken cancellationToken)
        {
            await _context.Types.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }

        public async Task<bool> UpdateAsync(MessageType entity, CancellationToken cancellationToken)
        {
            await _context.Types
                .Where(x => x.Id == entity.Id)
                .ExecuteUpdateAsync(z => z
                    .SetProperty(a => a.Name, a => entity.Name)
                    .SetProperty(a => a.ModifyUserName, a => entity.ModifyUserName)
                    .SetProperty(a => a.ModifyDate, a => entity.ModifyDate), cancellationToken);

            return true;
        }

        public async Task<bool> DeleteAsync(MessageType entity, CancellationToken cancellationToken)
        {
            await _context.Types
                .Where(x => x.Id == entity.Id)
                .ExecuteUpdateAsync(z => z
                    .SetProperty(a => a.IsRemove, a => entity.IsRemove)
                    .SetProperty(a => a.ModifyUserName, a => entity.ModifyUserName)
                    .SetProperty(a => a.ModifyDate, a => entity.ModifyDate), cancellationToken);

            return true;
        }        
    }
}
