using Microsoft.EntityFrameworkCore;
using NotificationMicroservice.Domain.Entity;
using NotificationMicroservice.Domain.Interfaces.Repository;

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
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<Guid> AddAsync(MessageTemplate entity, CancellationToken cancellationToken)
        {
            await _context.Templates.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }           

        public async Task<bool> UpdateAsync(MessageTemplate entity, CancellationToken cancellationToken)
        {
            await _context.Templates
                .Where(x => x.Id == entity.Id)
                .ExecuteUpdateAsync(z => z
                    .SetProperty(a => a.Type, a => entity.Type)
                    .SetProperty(a => a.Language, a => entity.Language)
                    .SetProperty(a => a.Template, a => entity.Template)
                    .SetProperty(a => a.IsRemove, a => entity.IsRemove)
                    .SetProperty(a => a.ModifyUserName, a => entity.ModifyUserName)
                    .SetProperty(a => a.ModifyDate, a => entity.ModifyDate), cancellationToken);

            return true;
        }

        public async Task<bool> DeleteAsync(MessageTemplate entity, CancellationToken cancellationToken)
        {
            await _context.Templates
                .Where(x => x.Id == entity.Id)
                .ExecuteUpdateAsync(z => z
                    .SetProperty(a => a.IsRemove, a => entity.IsRemove)
                    .SetProperty(a => a.ModifyUserName, a => entity.ModifyUserName)
                    .SetProperty(a => a.ModifyDate, a => entity.ModifyDate), cancellationToken);

            return true;
        }
    }
}
