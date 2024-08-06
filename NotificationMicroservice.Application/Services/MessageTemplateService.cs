using AutoMapper;
using NotificationMicroservice.Application.Interface;
using NotificationMicroservice.Application.Model.Template;
using NotificationMicroservice.Domain.Entity;
using NotificationMicroservice.Domain.Interfaces.Repository;


namespace NotificationMicroservice.Application.Services
{
    public class MessageTemplateService : ITemplateApplicationService
    {
        private readonly IMessageTemplateRepository _messageTemplateRepository;
        private readonly ITypeApplicationService _messageTypeService;
        private readonly IMapper _mapper;
        private readonly CancellationTokenSource _cancelTokenSource = new CancellationTokenSource();

        public MessageTemplateService(IMessageTemplateRepository messageTemplateRepository, ITypeApplicationService messageTypeService, IMapper mapper)
        {
            _messageTemplateRepository = messageTemplateRepository;
            _messageTypeService = messageTypeService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TemplateModel>> GetAllAsync()
        {
            var dbEntities = await _messageTemplateRepository.GetAllAsync(_cancelTokenSource.Token, true);

            return  dbEntities.Select(_mapper.Map<TemplateModel>);
        }

        public async Task<TemplateModel?> GetByIdAsync(Guid id)
        {
            var dbEntity = await _messageTemplateRepository.GetByIdAsync(id, _cancelTokenSource.Token);

            return dbEntity is null ? null : _mapper.Map<TemplateModel>(dbEntity);
        }

        public async Task<Guid> AddAsync(CreateTemplateModel messageTemplate)
        {
            var typeQ = await _messageTypeService.GetByIdAsync(messageTemplate.MessageTypeId);

            if (typeQ is null)
            {
                throw new Exception ($"MessageType {messageTemplate.MessageTypeId} not found!");
            }
            var type = _mapper.Map<MessageType>(typeQ);

            var template = new MessageTemplate(Guid.NewGuid(), type, messageTemplate.Language, messageTemplate.Template, true, messageTemplate.CreateUserName, DateTime.UtcNow, null, null);

            return await _messageTemplateRepository.AddAsync(template, _cancelTokenSource.Token);
        }

        public async Task<bool> UpdateAsync(EditTemplateModel messageTemplate)
        {
            var typeQ = await _messageTypeService.GetByIdAsync(messageTemplate.MessageTypeId);

            if (typeQ is null)
            {
                throw new Exception($"MessageType {messageTemplate.MessageTypeId} not found!");
            }
            var type = _mapper.Map<MessageType>(typeQ);

            var template = await _messageTemplateRepository.GetByIdAsync(messageTemplate.Id, _cancelTokenSource.Token);

            if (template is null)
            {
                throw new Exception($"MessageTemplate {messageTemplate.Id} not found!");
            }

            template.Update(type, messageTemplate.Language, messageTemplate.Template, messageTemplate.IsRemove, messageTemplate.ModifyUserName, DateTime.UtcNow);

            return await _messageTemplateRepository.UpdateAsync(template, _cancelTokenSource.Token);

        }

        public async Task<bool> DeleteAsync(EditTemplateModel messageTemplate)
        {
            //var entityDb = new TemplateEntity
            //{
            //    Id = messageTemplate.Id,
            //    TypeId = messageTemplate.MessageType.Id,
            //    Language = messageTemplate.Language,
            //    Template = messageTemplate.Template,
            //    IsRemove = messageTemplate.IsRemove,
            //    CreateUserName = messageTemplate.CreateUserName,
            //    CreateDate = messageTemplate.CreateDate,
            //    ModifyUserName = messageTemplate.ModifyUserName,
            //    ModifyDate = messageTemplate.ModifyDate,
            //};

            //return await _messageTemplateRepository.DeleteAsync(entityDb, _cancelTokenSource.Token);
            return false;
        }
    }
}
