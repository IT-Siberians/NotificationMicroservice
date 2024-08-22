using Microsoft.EntityFrameworkCore;
using NotificationMicroservice.DataAccess.Abstractions;
using NotificationMicroservice.Domain.Entities;

namespace NotificationMicroservice.DataAccess.Repository
{
    public class MessageTemplateRepository : IMessageTemplateRepository
    {
        private readonly NotificationMicroserviceDbContext _context;

        public MessageTemplateRepository(NotificationMicroserviceDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Запросить все шаблоны сообщений из базы
        /// </summary>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <param name="asNoTracking">Вызвать с AsNoTracking</param>
        /// <returns>Список сущностей</returns>
        public async Task<IEnumerable<MessageTemplate>> GetAllAsync(CancellationToken cancellationToken, bool asNoTracking = false)
        {
            return await (asNoTracking ? _context.Templates.AsNoTracking() : _context.Templates)
                .ToListAsync(cancellationToken);
        }

        public async Task<MessageTemplate?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _context.Templates
                .Where(x => x.Id == id)
                .AsNoTracking()
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<Guid> AddAsync(MessageTemplate entity, CancellationToken cancellationToken)
        {
            _context.Types.Attach(entity.Type);
            await _context.Templates.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }

        public async Task<bool> UpdateAsync(MessageTemplate entity, CancellationToken cancellationToken)
        {
            _context.Types.Attach(entity.Type);
            _context.Templates.Update(entity);

            return await _context.SaveChangesAsync(cancellationToken) == 1 ? true : false;
        }

        public async Task<bool> DeleteAsync(MessageTemplate entity, CancellationToken cancellationToken)
        {
            return await UpdateAsync(entity, cancellationToken);
        }
    }
}
