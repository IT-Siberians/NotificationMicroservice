using AutoMapper;
using NotificationMicroservice.DataAccess.Entities;
using NotificationMicroservice.Domain.Interfaces.Repository;
using NotificationMicroservice.Domain.Interfaces.Services;
using NotificationMicroservice.Domain.Models;

namespace NotificationMicroservice.Application.Services
{
    public class MessageTypeService : IMessageTypeService
    {
        private readonly IMessageTypeRepository<TypeEntity, Guid> _messageTypeRepository;
        private readonly CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
        private readonly IMapper _mapper;

        public MessageTypeService(IMessageTypeRepository<TypeEntity, Guid> messageTypeRepository)
        {
            _messageTypeRepository = messageTypeRepository;
        }

        public async Task<IEnumerable<MessageType>> GetAllAsync()
        {
            var dbEntities = await _messageTypeRepository.GetAllAsync(cancelTokenSource.Token, true);           

            return dbEntities.Select(z => new MessageType(
                                        z.Id,
                                        z.Name,
                                        z.IsRemove,
                                        z.CreateUserName,
                                        z.CreateDate,
                                        z.ModifyUserName,
                                        z.ModifyDate));
        }

        public async Task<MessageType>? GetByIdAsync(Guid id)
        {
            var dbEntity = await _messageTypeRepository.GetByIdAsync(id, cancelTokenSource.Token);
            
            if (dbEntity == null) {
                throw new InvalidOperationException("!!!!Alarm!!!!");
            }

            // _mapper.Map<MessageType>(MessageEntity);

            return new MessageType(
                    dbEntity.Id,
                    dbEntity.Name,
                    dbEntity.IsRemove,
                    dbEntity.CreateUserName,
                    dbEntity.CreateDate,
                    dbEntity.ModifyUserName,
                    dbEntity.ModifyDate);
        }
        public async Task<Guid> AddAsync(MessageType messageType)
        {
            var messageEntity = new TypeEntity()
            {
                Id = messageType.Id,
                Name = messageType.Name,
                IsRemove = messageType.IsRemove,
                CreateUserName = messageType.CreateUserName,
                CreateDate = messageType.CreateDate,
                ModifyUserName = messageType.ModifyUserName,
                ModifyDate = messageType.ModifyDate
            };

            return await _messageTypeRepository.AddAsync(messageEntity, cancelTokenSource.Token);
        }

        public async Task<bool> UpdateAsync(MessageType messageType)
        {
            var messageEntity = new TypeEntity()
            {
                Id = messageType.Id,
                Name = messageType.Name,
                IsRemove = messageType.IsRemove,
                CreateUserName = messageType.CreateUserName,
                CreateDate = messageType.CreateDate,
                ModifyUserName = messageType.ModifyUserName,
                ModifyDate = messageType.ModifyDate
            };

            return await _messageTypeRepository.UpdateAsync(messageEntity, cancelTokenSource.Token);
        }

        public async Task<bool> DeleteAsync(MessageType messageType)
        {
            var messageEntity = new TypeEntity()
            {
                Id = messageType.Id,
                Name = messageType.Name,
                IsRemove = messageType.IsRemove,
                CreateUserName = messageType.CreateUserName,
                CreateDate = messageType.CreateDate,
                ModifyUserName = messageType.ModifyUserName,
                ModifyDate = messageType.ModifyDate
            };

            return await _messageTypeRepository.DeleteAsync(messageEntity, cancelTokenSource.Token);
        }
    }
}
