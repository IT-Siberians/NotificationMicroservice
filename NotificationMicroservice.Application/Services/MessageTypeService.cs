using AutoMapper;
using NotificationMicroservice.Application.Abstractions;
using NotificationMicroservice.Application.Model.Type;
using NotificationMicroservice.DataAccess.Repository.Abstractions;
using NotificationMicroservice.Domain.Entities;

namespace NotificationMicroservice.Application.Services
{
    public class MessageTypeService : ITypeApplicationService
    {
        private readonly IMessageTypeRepository _messageTypeRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly CancellationTokenSource _cancelTokenSource = new CancellationTokenSource();

        public MessageTypeService(IMessageTypeRepository messageTypeRepository, IUserRepository userRepository, IMapper mapper)
        {
            _messageTypeRepository = messageTypeRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TypeModel>> GetAllAsync()
        {
            var dbEntities = await _messageTypeRepository.GetAllAsync(_cancelTokenSource.Token, true);

            return dbEntities.Select(_mapper.Map<TypeModel>);
        }

        public async Task<TypeModel?> GetByIdAsync(Guid id)
        {
            var dbEntity = await _messageTypeRepository.GetByIdAsync(id, _cancelTokenSource.Token);

            return dbEntity is null ? null : _mapper.Map<TypeModel>(dbEntity);
        }

        public async Task<Guid?> AddAsync(CreateTypeModel type)
        {
            var user = await _userRepository.GetByIdAsync(type.CreatedUserId, _cancelTokenSource.Token);

            if (user is null)
            {
                return null;
            }

            var typeNew = new MessageType(type.Name, false, user, DateTime.UtcNow, null, null);

            return await _messageTypeRepository.AddAsync(typeNew, _cancelTokenSource.Token);
        }

        public async Task<bool> UpdateAsync(EditTypeModel messageType)
        {
            var user = await _userRepository.GetByIdAsync(messageType.ModifiedUserId, _cancelTokenSource.Token);

            if (user is null)
            {
                return false;
            }

            var type = await _messageTypeRepository.GetByIdAsync(messageType.Id, _cancelTokenSource.Token);

            if (type is null || type.IsRemoved)
            {
                return false;
            }

            type.Update(messageType.Name, false, user, DateTime.UtcNow);

            return await _messageTypeRepository.UpdateAsync(type, _cancelTokenSource.Token);
        }

        public async Task<bool> DeleteAsync(DeleteTypeModel messageType)
        {
            var user = await _userRepository.GetByIdAsync(messageType.ModifiedUserId, _cancelTokenSource.Token);

            if (user is null)
            {
                return false;
            }

            var type = await _messageTypeRepository.GetByIdAsync(messageType.Id, _cancelTokenSource.Token);

            if (type is null)
            {
                return false;
            }

            type.Delete(user, DateTime.UtcNow);

            return await _messageTypeRepository.DeleteAsync(type, _cancelTokenSource.Token);
        }

    }
}
