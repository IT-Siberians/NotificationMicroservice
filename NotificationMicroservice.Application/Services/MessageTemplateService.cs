using AutoMapper;
using NotificationMicroservice.Application.Abstractions;
using NotificationMicroservice.Application.Model.Template;
using NotificationMicroservice.DataAccess.Repository.Abstractions;
using NotificationMicroservice.Domain.Entities;


namespace NotificationMicroservice.Application.Services
{
    public class MessageTemplateService(IMessageTemplateRepository templateRepository, IMessageTypeRepository typeRepository, IUserRepository userRepository, IMapper mapper) : ITemplateApplicationService
    {
        private readonly CancellationTokenSource _cancelTokenSource = new CancellationTokenSource();

        public async Task<IEnumerable<TemplateModel>> GetAllAsync()
        {
            var dbEntities = await templateRepository.GetAllAsync(_cancelTokenSource.Token, true);

            return dbEntities.Select(mapper.Map<TemplateModel>);
        }

        public async Task<TemplateModel?> GetByIdAsync(Guid id)
        {
            var dbEntity = await templateRepository.GetByIdAsync(id, _cancelTokenSource.Token);

            return dbEntity is null ? null : mapper.Map<TemplateModel>(dbEntity);
        }

        public async Task<Guid?> AddAsync(CreateTemplateModel messageTemplate)
        {
            var user = await userRepository.GetByIdAsync(messageTemplate.CreatedUserId, _cancelTokenSource.Token);

            if (user is null)
            {
                return null;
            }

            var type = await typeRepository.GetByIdAsync(messageTemplate.MessageTypeId, _cancelTokenSource.Token);

            if (type is null || type.IsRemoved)
            {
                return null;
            }

            var template = new MessageTemplate(type, messageTemplate.Language, messageTemplate.Template, false, user, DateTime.UtcNow, null, null);

            return await templateRepository.AddAsync(template, _cancelTokenSource.Token);
        }

        public async Task<bool> UpdateAsync(UpdateTemplateModel messageTemplate)
        {
            var user = await userRepository.GetByIdAsync(messageTemplate.ModifiedByUserId, _cancelTokenSource.Token);

            if (user is null)
            {
                return false;
            }

            var type = await typeRepository.GetByIdAsync(messageTemplate.MessageTypeId, _cancelTokenSource.Token);

            if (type is null || type.IsRemoved)
            {
                return false;
            }

            var template = await templateRepository.GetByIdAsync(messageTemplate.Id, _cancelTokenSource.Token);

            if (template is null)
            {
                return false;
            }

            template.Update(type, messageTemplate.Language, messageTemplate.Template, messageTemplate.IsRemoved, user, DateTime.UtcNow);

            return await templateRepository.UpdateAsync(template, _cancelTokenSource.Token);

        }

        public async Task<bool> DeleteAsync(DeleteTemplateModel messageTemplate)
        {
            var user = await userRepository.GetByIdAsync(messageTemplate.ModifiedByUserId, _cancelTokenSource.Token);

            if (user is null)
            {
                return false;
            }

            var template = await templateRepository.GetByIdAsync(messageTemplate.Id, _cancelTokenSource.Token);

            if (template is null)
            {
                return false;
            }

            template.Delete(user, DateTime.UtcNow);

            return await templateRepository.DeleteAsync(template, _cancelTokenSource.Token);
        }
    }
}
