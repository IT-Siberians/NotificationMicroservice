using NotificationMicroservice.DataAccess.Entities;
using NotificationMicroservice.Domain.Interfaces.Repository;
using NotificationMicroservice.Domain.Interfaces.Services;
using NotificationMicroservice.Domain.Models;

namespace NotificationMicroservice.Application.Services
{
    public class MessageTemplateService : IMessageTemplateService
    {
        private readonly IMessageTemplateRepository<TemplateEntity, Guid> _messageTemplateRepository;
        private readonly CancellationTokenSource _cancelTokenSource = new CancellationTokenSource();

        public MessageTemplateService(IMessageTemplateRepository<TemplateEntity, Guid> messageTemplateRepository)
        {
            _messageTemplateRepository = messageTemplateRepository;
        }

        public async Task<IEnumerable<MessageTemplate>> GetAllAsync()
        {
            var entitiesDb = await _messageTemplateRepository.GetAllAsync(_cancelTokenSource.Token, true);

            return entitiesDb.Select(z => new MessageTemplate(
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
                                z.ModifyDate));
        }

        public async Task<MessageTemplate>? GetByIdAsync(Guid id)
        {
            var entityDb = await _messageTemplateRepository.GetByIdAsync(id, _cancelTokenSource.Token);
            
            if (entityDb == null)
            {
                throw new InvalidOperationException("!!!ALARM!!!");
            }
            
            return new MessageTemplate(
                    entityDb.Id,
                    new MessageType(
                        entityDb.Type.Id,
                        entityDb.Type.Name,
                        entityDb.Type.IsRemove,
                        entityDb.Type.CreateUserName,
                        entityDb.Type.CreateDate,
                        entityDb.Type.ModifyUserName,
                        entityDb.Type.ModifyDate),
                    entityDb.Language,
                    entityDb.Template,
                    entityDb.IsRemove,
                    entityDb.CreateUserName,
                    entityDb.CreateDate,
                    entityDb.ModifyUserName,
                    entityDb.ModifyDate);
        }

        public async Task<Guid> AddAsync(MessageTemplate messageTemplate)
        {
            var entityDb = new TemplateEntity
            {
                Id = messageTemplate.Id,
                TypeId = messageTemplate.MessageType.Id,
                Language = messageTemplate.Language,
                Template = messageTemplate.Template,
                IsRemove = messageTemplate.IsRemove,
                CreateUserName = messageTemplate.CreateUserName,
                CreateDate = messageTemplate.CreateDate,
                ModifyUserName = messageTemplate.ModifyUserName,
                ModifyDate = messageTemplate.ModifyDate,
            };

            return await _messageTemplateRepository.AddAsync(entityDb, _cancelTokenSource.Token);
        }

        public async Task<bool> UpdateAsync(MessageTemplate messageTemplate)
        {
            var entityDb = new TemplateEntity
            {
                Id = messageTemplate.Id,
                TypeId = messageTemplate.MessageType.Id,
                Language = messageTemplate.Language,
                Template = messageTemplate.Template,
                IsRemove = messageTemplate.IsRemove,
                CreateUserName = messageTemplate.CreateUserName,
                CreateDate = messageTemplate.CreateDate,
                ModifyUserName = messageTemplate.ModifyUserName,
                ModifyDate = messageTemplate.ModifyDate,
            };

            return await _messageTemplateRepository.UpdateAsync(entityDb, _cancelTokenSource.Token);
        }

        public async Task<bool> DeleteAsync(MessageTemplate messageTemplate)
        {
            var entityDb = new TemplateEntity
            {
                Id = messageTemplate.Id,
                TypeId = messageTemplate.MessageType.Id,
                Language = messageTemplate.Language,
                Template = messageTemplate.Template,
                IsRemove = messageTemplate.IsRemove,
                CreateUserName = messageTemplate.CreateUserName,
                CreateDate = messageTemplate.CreateDate,
                ModifyUserName = messageTemplate.ModifyUserName,
                ModifyDate = messageTemplate.ModifyDate,
            };

            return await _messageTemplateRepository.DeleteAsync(entityDb, _cancelTokenSource.Token);
        }
    }
}
