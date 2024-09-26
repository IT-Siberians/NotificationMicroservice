using AutoMapper;
using NotificationMicroservice.Application.Abstractions;
using NotificationMicroservice.Application.Model.Type;
using NotificationMicroservice.DataAccess.Repository.Abstractions;
using NotificationMicroservice.Domain.Entities;

namespace NotificationMicroservice.Application.Services
{
    public class MessageTypeService(IMessageTypeRepository messageTypeRepository, IUserRepository userRepository, IMapper mapper) : ITypeApplicationService
    {
        private readonly CancellationTokenSource _cancelTokenSource = new CancellationTokenSource();

        public async Task<IEnumerable<TypeModel>> GetAllAsync()
        {
            var dbEntities = await messageTypeRepository.GetAllAsync(_cancelTokenSource.Token, true);

            return dbEntities.Select(mapper.Map<TypeModel>);
        }

        public async Task<TypeModel?> GetByIdAsync(Guid id)
        {
            var dbEntity = await messageTypeRepository.GetByIdAsync(id, _cancelTokenSource.Token);

            return dbEntity is null ? null : mapper.Map<TypeModel>(dbEntity);
        }

        public async Task<Guid?> AddAsync(CreateTypeModel type)
        {
            var user = await userRepository.GetByIdAsync(type.CreatedByUserId, _cancelTokenSource.Token);

            if (user is null)
            {
                return null;
            }

            var typeNew = new MessageType(type.Name, false, user, DateTime.UtcNow, null, null);

            return await messageTypeRepository.AddAsync(typeNew, _cancelTokenSource.Token);
        }

        public async Task<bool> UpdateAsync(UpdateTypeModel messageType)
        {
            var user = await userRepository.GetByIdAsync(messageType.ModifiedByUserId, _cancelTokenSource.Token);

            if (user is null)
            {
                return false;
            }

            var type = await messageTypeRepository.GetByIdAsync(messageType.Id, _cancelTokenSource.Token);

            if (type is null || type.IsRemoved)
            {
                return false;
            }

            type.Update(messageType.Name, false, user, DateTime.UtcNow);

            return await messageTypeRepository.UpdateAsync(type, _cancelTokenSource.Token);
        }

        public async Task<bool> DeleteAsync(DeleteTypeModel messageType)
        {
            var user = await userRepository.GetByIdAsync(messageType.ModifiedByUserId, _cancelTokenSource.Token);

            if (user is null)
            {
                return false;
            }

            var type = await messageTypeRepository.GetByIdAsync(messageType.Id, _cancelTokenSource.Token);

            if (type is null)
            {
                return false;
            }

            type.Delete(user, DateTime.UtcNow);

            return await messageTypeRepository.DeleteAsync(type, _cancelTokenSource.Token);
        }

    }
}
