using AutoMapper;
using NotificationMicroservice.Application.Interface;
using NotificationMicroservice.Application.Model.Message;
using NotificationMicroservice.Domain.Entity;
using NotificationMicroservice.Domain.Interfaces.Repository;

namespace NotificationMicroservice.Application.Services
{
    public class MessageService : IMessageApplicationService
    {
        private readonly IMessageRepository _messageRepository;
        private readonly ITypeApplicationService _typeApplicationService;
        private readonly IMapper _mapper;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

        public MessageService(IMessageRepository messageRepository, ITypeApplicationService typeApplicationService, IMapper mapper)
        {
            _messageRepository = messageRepository;
            _typeApplicationService = typeApplicationService;
            _mapper = mapper;
        }

        public async Task<Guid> AddAsync(CreateMessageModel messageCreate)
        {
            var typeQ = await _typeApplicationService.GetByIdAsync(messageCreate.MessageTypeId);
            
            if (typeQ is null)
            {
                throw new ArgumentNullException($"MessageType {messageCreate.MessageTypeId} not found!");
            }

            var type = _mapper.Map<MessageType>(typeQ);

            var message = new Message(Guid.NewGuid(), type, messageCreate.MessageText, messageCreate.Direction, DateTime.UtcNow);

            var messageId = await _messageRepository.AddAsync(message, _cancellationTokenSource.Token);

            return messageId;
        }

        public async Task<IEnumerable<MessageModel>> GetAllAsync()
        {
            var dbEntities = await _messageRepository.GetAllAsync(_cancellationTokenSource.Token, true);

            return dbEntities.Select(_mapper.Map<MessageModel>);
        }

        public async Task<MessageModel?> GetByIdAsync(Guid id)
        {
            var dbEntity = await _messageRepository.GetByIdAsync(id, _cancellationTokenSource.Token);

            return dbEntity is null ? null : _mapper.Map<MessageModel>(dbEntity);
        }
    }
}
