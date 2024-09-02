using AutoMapper;
using NotificationMicroservice.Application.Abstractions;
using NotificationMicroservice.Application.Model.Template;
using NotificationMicroservice.DataAccess.Repository.Abstractions;
using NotificationMicroservice.Domain.Entities;


namespace NotificationMicroservice.Application.Services
{
    public class MessageTemplateService : ITemplateApplicationService
    {
        private readonly IMessageTemplateRepository _templateRepository;
        private readonly IMessageTypeRepository _typeRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly CancellationTokenSource _cancelTokenSource = new CancellationTokenSource();

        public MessageTemplateService(IMessageTemplateRepository templateRepository, IMessageTypeRepository typeRepository, IUserRepository userRepository, IMapper mapper)
        {
            _templateRepository = templateRepository;
            _typeRepository = typeRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TemplateModel>> GetAllAsync()
        {
            var dbEntities = await _templateRepository.GetAllAsync(_cancelTokenSource.Token, true);

            return dbEntities.Select(_mapper.Map<TemplateModel>);
        }

        public async Task<TemplateModel?> GetByIdAsync(Guid id)
        {
            var dbEntity = await _templateRepository.GetByIdAsync(id, _cancelTokenSource.Token);

            return dbEntity is null ? null : _mapper.Map<TemplateModel>(dbEntity);
        }

        public async Task<Guid?> AddAsync(CreateTemplateModel messageTemplate)
        {
            var user = await _userRepository.GetByIdAsync(messageTemplate.CreatedUserId, _cancelTokenSource.Token);

            if (user is null)
            {
                return null;
            }

            var type = await _typeRepository.GetByIdAsync(messageTemplate.MessageTypeId, _cancelTokenSource.Token);

            if (type is null || type.IsRemoved)
            {
                return null;
            }

            var template = new MessageTemplate(type, messageTemplate.Language, messageTemplate.Template, false, user, DateTime.UtcNow, null, null);

            return await _templateRepository.AddAsync(template, _cancelTokenSource.Token);
        }

        public async Task<bool> UpdateAsync(EditTemplateModel messageTemplate)
        {
            var user = await _userRepository.GetByIdAsync(messageTemplate.ModifiedUserId, _cancelTokenSource.Token);

            if (user is null)
            {
                return false;
            }

            var type = await _typeRepository.GetByIdAsync(messageTemplate.MessageTypeId, _cancelTokenSource.Token);

            if (type is null || type.IsRemoved)
            {
                return false;
            }

            var template = await _templateRepository.GetByIdAsync(messageTemplate.Id, _cancelTokenSource.Token);

            if (template is null)
            {
                return false;
            }

            template.Update(type, messageTemplate.Language, messageTemplate.Template, messageTemplate.IsRemoved, user, DateTime.UtcNow);

            return await _templateRepository.UpdateAsync(template, _cancelTokenSource.Token);

        }

        public async Task<bool> DeleteAsync(DeleteTemplateModel messageTemplate)
        {
            var user = await _userRepository.GetByIdAsync(messageTemplate.ModifiedUserId, _cancelTokenSource.Token);

            if (user is null)
            {
                return false;
            }

            var template = await _templateRepository.GetByIdAsync(messageTemplate.Id, _cancelTokenSource.Token);

            if (template is null)
            {
                return false;
            }

            template.Delete(user, DateTime.UtcNow);

            return await _templateRepository.DeleteAsync(template, _cancelTokenSource.Token);
        }
    }
}
