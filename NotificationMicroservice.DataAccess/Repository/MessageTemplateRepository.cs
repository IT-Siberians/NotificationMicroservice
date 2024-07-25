using Microsoft.EntityFrameworkCore;
using NotificationMicroservice.DataAccess.Entities;
using NotificationMicroservice.Domain.Interfaces.Model;
using NotificationMicroservice.Domain.Interfaces.Repository;
using NotificationMicroservice.Domain.Models;

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
                .Select(z => new MessageTemplate(
                    z.Id,
                    new MessageType(
                        z.Type.Id,
                        z.Type.Name,
                        z.Type.IsRemove,
                        z.Type.CreateUserName,
                        z.Type.CreateDate,
                        z.Type.ModifyUserName,
                        z.Type.ModifyDate),
                    z.Language,
                    z.Template,
                    z.IsRemove,
                    z.CreateUserName,
                    z.CreateDate,
                    z.ModifyUserName,
                    z.ModifyDate))
                .ToListAsync(cancellationToken);
        }

        public async Task<MessageTemplate>? GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _context.Templates
                .Where(x => x.Id == id)
                .Select(z => new MessageTemplate(
                    z.Id,
                    new MessageType(
                        z.Type.Id,
                        z.Type.Name,
                        z.Type.IsRemove,
                        z.Type.CreateUserName,
                        z.Type.CreateDate,
                        z.Type.ModifyUserName,
                        z.Type.ModifyDate),
                    z.Language,
                    z.Template,
                    z.IsRemove,
                    z.CreateUserName,
                    z.CreateDate,
                    z.ModifyUserName,
                    z.ModifyDate))
                .FirstAsync(cancellationToken);
        }

        public async Task<Guid> AddAsync(MessageTemplate entity, CancellationToken cancellationToken)
        {
            var templateEntity = new TemplateEntity
            {
                Id = entity.Id,
                TypeId = entity.MessageType.Id,
                Language = entity.Language,
                Template = entity.Template,
                IsRemove = entity.IsRemove,
                CreateUserName = entity.CreateUserName,
                CreateDate = entity.CreateDate,
                ModifyUserName = entity.ModifyUserName,
                ModifyDate = entity.ModifyDate,
            };

            await _context.Templates.AddAsync(templateEntity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }           

        public async Task<bool> UpdateAsync(MessageTemplate entity, CancellationToken cancellationToken)
        {
            await _context.Templates
                .Where(x => x.Id == entity.Id)
                .ExecuteUpdateAsync(z => z
                    .SetProperty(a => a.TypeId, a => entity.MessageType.Id)
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
