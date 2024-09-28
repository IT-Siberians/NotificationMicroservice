using AutoMapper;
using NotificationMicroservice.Application.Abstractions;
using NotificationMicroservice.Application.Model.Template;
using NotificationMicroservice.DataAccess.Repository.Abstractions;
using NotificationMicroservice.Domain.Entities;
using NotificationMicroservice.Domain.Enums;
using NotificationMicroservice.Domain.ValueObjects;


namespace NotificationMicroservice.Application.Services
{
    public class MessageTemplateService(IMessageTemplateRepository templateRepository, IMessageTypeRepository typeRepository, IUserRepository userRepository, IMapper mapper) : ITemplateApplicationService
    {
        public async Task<IEnumerable<TemplateModel>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var dbEntities = await templateRepository.GetAllAsync(cancellationToken, true);

            return dbEntities.Select(mapper.Map<TemplateModel>);
        }

        public async Task<TemplateModel?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var dbEntity = await templateRepository.GetByIdAsync(id, cancellationToken);

            return dbEntity is null ? null : mapper.Map<TemplateModel>(dbEntity);
        }

        public async Task<IEnumerable<TemplateModel>> GetByTypeIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var dbEntities = await templateRepository.GetAllAsync(cancellationToken, true);

            if (dbEntities is null)
            {
                return null;
            }

            var result = dbEntities.Where(i => i.Type.Id == id).ToList();

            return result.Select(mapper.Map<TemplateModel>);
        }

        public async Task<Guid?> AddAsync(CreateTemplateModel messageTemplate, CancellationToken cancellationToken = default)
        {
            var user = await userRepository.GetByIdAsync(messageTemplate.CreatedByUserId, cancellationToken);

            if (user is null)
            {
                return null;
            }

            var type = await typeRepository.GetByIdAsync(messageTemplate.MessageTypeId, cancellationToken);

            if (type is null || type.IsRemoved)
            {
                return null;
            }

            var template = new MessageTemplate(type, (Language)Enum.Parse(typeof(Language), messageTemplate.Language), new Template(messageTemplate.Template), false, user, DateTime.UtcNow, null, null);

            return await templateRepository.AddAsync(template, cancellationToken);
        }

        public async Task<bool> UpdateAsync(UpdateTemplateModel messageTemplate, CancellationToken cancellationToken = default)
        {
            var user = await userRepository.GetByIdAsync(messageTemplate.ModifiedByUserId, cancellationToken);

            if (user is null)
            {
                return false;
            }

            var type = await typeRepository.GetByIdAsync(messageTemplate.MessageTypeId, cancellationToken);

            if (type is null || type.IsRemoved)
            {
                return false;
            }

            var template = await templateRepository.GetByIdAsync(messageTemplate.Id, cancellationToken);

            if (template is null)
            {
                return false;
            }

            template.Update(type, (Language)Enum.Parse(typeof(Language), messageTemplate.Language), new Template(messageTemplate.Template), messageTemplate.IsRemoved, user, DateTime.UtcNow);

            return await templateRepository.UpdateAsync(template, cancellationToken);
        }

        public async Task<bool> DeleteAsync(DeleteTemplateModel messageTemplate, CancellationToken cancellationToken = default)
        {
            var user = await userRepository.GetByIdAsync(messageTemplate.ModifiedByUserId, cancellationToken);

            if (user is null)
            {
                return false;
            }

            var template = await templateRepository.GetByIdAsync(messageTemplate.Id, cancellationToken);

            if (template is null)
            {
                return false;
            }

            template.Delete(user, DateTime.UtcNow);

            return await templateRepository.DeleteAsync(template, cancellationToken);
        }
    }
}
