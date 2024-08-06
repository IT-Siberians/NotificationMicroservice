using AutoMapper;
using NotificationMicroservice.Application.Interface;
using NotificationMicroservice.Application.Model.Message;
using NotificationMicroservice.Domain.Interfaces.Repository;

namespace NotificationMicroservice.Application.Services
{
    public class MessageService : IMessageApplicationService
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IMapper _mapper;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

        public MessageService(IMessageRepository messageRepository, IMapper mapper)
        {
            _messageRepository = messageRepository;
            _mapper = mapper;
        }

        public Task<Guid> AddAsync(MessageModel messageTemplate)
        {
            throw new NotImplementedException();
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
