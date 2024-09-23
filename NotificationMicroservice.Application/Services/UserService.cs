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
        private readonly CancellationTokenSource _cancelTokenSource = new CancellationTokenSource();

        public async Task<IEnumerable<UserModel>> GetAllAsync()
        {
            var users = await userRepository.GetAllAsync(_cancelTokenSource.Token, true);

            return users.Select(mapper.Map<UserModel>);
        }

        public async Task<UserModel?> GetByIdAsync(Guid id)
        {
            var user = await userRepository.GetByIdAsync(id, _cancelTokenSource.Token);

            return user is null ? null : mapper.Map<UserModel>(user);
        }

        public async Task<Guid?> AddAsync(CreateUserModel createUser)
        {
            var user = await userRepository.GetByIdAsync(createUser.Id, _cancelTokenSource.Token);

            if (user == null)
            {
                return null;
            }

            var newUser = new User(createUser.Id, new Username(createUser.Username), new FullName(createUser.FullName), new Email(createUser.Email));

            return await userRepository.AddAsync(newUser, _cancelTokenSource.Token);
        }

        public async Task<bool> UpdateAsync(UpdateUserModel updateUser)
        {
            var user = await userRepository.GetByIdAsync(updateUser.Id, _cancelTokenSource.Token);

            if (user == null)
            {
                return false;
            }

            user.Update(new FullName(updateUser.FullName), new Email(updateUser.Email));

            return await userRepository.UpdateAsync(user, _cancelTokenSource.Token);
        }
    }
}
