using AutoMapper;
using NotificationMicroservice.Application.Model.User;
using NotificationMicroservice.Application.Services.Abstractions;
using NotificationMicroservice.DataAccess.Repository.Abstractions;
using NotificationMicroservice.Domain.Entities;
using NotificationMicroservice.Domain.ValueObjects;

namespace NotificationMicroservice.Application.Services
{
    public class UserService(IUserRepository userRepository, IMapper mapper) : IUserApplicationService
    {
        public async Task<IEnumerable<UserModel>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var users = await userRepository.GetAllAsync(cancellationToken, true);

            return users.Select(mapper.Map<UserModel>);
        }

        public async Task<UserModel?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var user = await userRepository.GetByIdAsync(id, cancellationToken);

            return user is null ? null : mapper.Map<UserModel>(user);
        }

        public async Task<Guid?> AddAsync(CreateUserModel createUser, CancellationToken cancellationToken = default)
        {
            var user = await userRepository.GetByIdAsync(createUser.Id, cancellationToken);

            if (user is not null)
            {
                return null;
            }

            var newUser = new User(createUser.Id, new Username(createUser.Username), new FullName(createUser.FullName), new Email(createUser.Email));

            return await userRepository.AddAsync(newUser, cancellationToken);
        }

        public async Task<bool> UpdateAsync(UpdateUserModel updateUser, CancellationToken cancellationToken = default)
        {
            var user = await userRepository.GetByIdAsync(updateUser.Id, cancellationToken);

            if (user == null)
            {
                return false;
            }

            user.Update(new FullName(updateUser.FullName), new Email(updateUser.Email));

            return await userRepository.UpdateAsync(user, cancellationToken);
        }
    }
}
