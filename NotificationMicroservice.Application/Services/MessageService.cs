using AutoMapper;
using NotificationMicroservice.Application.Abstractions;
using NotificationMicroservice.Application.Model.Message;
using NotificationMicroservice.DataAccess.Abstractions;
using NotificationMicroservice.Domain.Entities;

namespace NotificationMicroservice.Application.Services
{
    public class MessageService : IMessageApplicationService
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IMessageTypeRepository _typeRepository;
        private readonly IMapper _mapper;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

        public MessageService(IMessageRepository messageRepository, IMessageTypeRepository typeRepository, IMapper mapper)
        {
            _messageRepository = messageRepository;
            _typeRepository = typeRepository;
            _mapper = mapper;
        }

        public async Task<Guid?> AddAsync(CreateMessageModel messageCreate)
        {
            var type = await _typeRepository.GetByIdAsync(messageCreate.MessageTypeId, _cancellationTokenSource.Token);
            
            if (type is null)
            {
                return null;
            }

            var message = new Message(Guid.NewGuid(), type, messageCreate.MessageText, messageCreate.Direction, DateTime.UtcNow);

            return await _messageRepository.AddAsync(message, _cancellationTokenSource.Token);
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
