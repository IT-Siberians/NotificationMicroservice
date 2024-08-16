using AutoMapper;
using NotificationMicroservice.Application.Abstractions;
using NotificationMicroservice.Application.Model.Type;
using NotificationMicroservice.DataAccess.Abstractions;
using NotificationMicroservice.Domain.Entities;

namespace NotificationMicroservice.Application.Services
{
    public class MessageTypeService : ITypeApplicationService
    {
        private readonly IMessageTypeRepository _messageTypeRepository;
        private readonly IMapper _mapper;
        private readonly CancellationTokenSource cancelTokenSource = new CancellationTokenSource();        

        public MessageTypeService(IMessageTypeRepository messageTypeRepository, IMapper mapper)
        {
            _messageTypeRepository = messageTypeRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TypeModel>> GetAllAsync()
        {
            var dbEntities = await _messageTypeRepository.GetAllAsync(cancelTokenSource.Token, true);

            return dbEntities.Select(_mapper.Map<TypeModel>);
        }

        public async Task<TypeModel?> GetByIdAsync(Guid id)
        {
            var dbEntity = await _messageTypeRepository.GetByIdAsync(id, cancelTokenSource.Token);

            return dbEntity is null ? null : _mapper.Map<TypeModel>(dbEntity);
        }

        public async Task<Guid> AddAsync(CreateTypeModel type)
        {
            var typeNew = new MessageType(Guid.NewGuid(), type.Name, false, type.CreateUserName, DateTime.UtcNow, null, null);

            var typeId = await _messageTypeRepository.AddAsync(typeNew, cancelTokenSource.Token);

            return typeId;
        }

        public async Task<bool> UpdateAsync(EditTypeModel type1)
        {
            var type = await GetByIdAsync(type1.Id);

            if (type is null || type.IsRemove)
            {
                return false;
            }

            var typeNew = _mapper.Map<MessageType>(type);

            typeNew.Update(type1.Name, false, type1.ModifyUserName, DateTime.UtcNow);

            var result = await _messageTypeRepository.UpdateAsync(typeNew, cancelTokenSource.Token);

            return result;
        }

        public async Task<bool> DeleteAsync(EditTypeModel type1)
        {
            var type = await GetByIdAsync(type1.Id);

            if (type is null)
            {
                return false;
            }

            var typeNew = _mapper.Map<MessageType>(type);

            typeNew.Delete(type1.ModifyUserName, DateTime.UtcNow);

            var result = await _messageTypeRepository.DeleteAsync(typeNew, cancelTokenSource.Token);

            return result;
        }

    }
}
