using AutoMapper;
using NotificationMicroservice.Application.Abstractions;
using NotificationMicroservice.Application.Model.Template;
using NotificationMicroservice.DataAccess.Abstractions;
using NotificationMicroservice.Domain.Entities;


namespace NotificationMicroservice.Application.Services
{
    public class MessageTemplateService : ITemplateApplicationService
    {
        private readonly IMessageTemplateRepository _templateRepository;
        private readonly IMessageTypeRepository _typeRepository;
        private readonly IMapper _mapper;
        private readonly CancellationTokenSource _cancelTokenSource = new CancellationTokenSource();

        public MessageTemplateService(IMessageTemplateRepository templateRepository, IMessageTypeRepository typeRepository, IMapper mapper)
        {
            _templateRepository = templateRepository;
            _typeRepository = typeRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TemplateModel>> GetAllAsync()
        {
            var dbEntities = await _templateRepository.GetAllAsync(_cancelTokenSource.Token, true);

            return  dbEntities.Select(_mapper.Map<TemplateModel>);
        }

        public async Task<TemplateModel?> GetByIdAsync(Guid id)
        {
            var dbEntity = await _templateRepository.GetByIdAsync(id, _cancelTokenSource.Token);

            return dbEntity is null ? null : _mapper.Map<TemplateModel>(dbEntity);
        }

        public async Task<Guid> AddAsync(CreateTemplateModel messageTemplate)
        {
            var type = await _typeRepository.GetByIdAsync(messageTemplate.MessageTypeId, _cancelTokenSource.Token);

            if (type is null)
            {
                throw new Exception ($"MessageType {messageTemplate.MessageTypeId} not found!");
            }     

            var template = new MessageTemplate(Guid.NewGuid(), type, messageTemplate.Language, messageTemplate.Template, false, messageTemplate.CreateUserName, DateTime.UtcNow, null, null);

            return await _templateRepository.AddAsync(template, _cancelTokenSource.Token);
        }

        public async Task<bool> UpdateAsync(EditTemplateModel messageTemplate)
        {
            var type = await _typeRepository.GetByIdAsync(messageTemplate.MessageTypeId, _cancelTokenSource.Token);

            if (type is null)
            {
                throw new Exception($"MessageType {messageTemplate.MessageTypeId} not found!");
            }

            var template = await _templateRepository.GetByIdAsync(messageTemplate.Id, _cancelTokenSource.Token);

            if (template is null)
            {
                throw new Exception($"MessageTemplate {messageTemplate.Id} not found!");
            }

            template.Update(type, messageTemplate.Language, messageTemplate.Template, messageTemplate.IsRemove, messageTemplate.ModifyUserName, DateTime.UtcNow);

            return await _templateRepository.UpdateAsync(template, _cancelTokenSource.Token);

        }

        public async Task<bool> DeleteAsync(EditTemplateModel messageTemplate)
        {
            
            var template = await _templateRepository.GetByIdAsync(messageTemplate.Id, _cancelTokenSource.Token);

            if (template is null)
            {
                throw new Exception($"MessageTemplate {messageTemplate.Id} not found!");
            }

            template.Delete(messageTemplate.ModifyUserName, DateTime.UtcNow);

            return await _templateRepository.DeleteAsync(template, _cancelTokenSource.Token);
        }
    }
}
