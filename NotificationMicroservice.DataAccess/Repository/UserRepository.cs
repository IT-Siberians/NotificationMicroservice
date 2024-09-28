using NotificationMicroservice.DataAccess.Repository.Abstractions;
using NotificationMicroservice.Domain.Entities;

namespace NotificationMicroservice.DataAccess.Repository
{
    /// <summary>
    /// Представляет репозиторий для управления сущностями <see cref="User"/> в базе данных.
    /// Реализует интерфейс <see cref="IUserRepository"/>.
    /// </summary>
    /// <param name="context">Контекст базы данных.</param>
    public class UserRepository(NotificationMicroserviceDbContext context) : BaseRepository<User, Guid>(context), IUserRepository
    {
        /// <summary>
        /// Асинхронно добавляет новую сущность <see cref="User"/> в базу данных и возвращает сгенерированный <see cref="User.Id"/>.
        /// </summary>
        /// <param name="user">Пользователь для добавления.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Результат задачи содержит сгенерированный ID добавленного пользователя.</returns>
        public async Task<Guid> AddAsync(User user, CancellationToken cancellationToken = default)
        {
            context.Users.Add(user);
            await context.SaveChangesAsync(cancellationToken);

            return user.Id;
        }

        /// <summary>
        /// Асинхронно обновляет существующую сущность <see cref="User"/> в базе данных.
        /// </summary>
        /// <param name="user">Пользователь для обновления.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Результат задачи содержит булевое значение, указывающее, были ли сохранены какие-либо изменения.</returns>
        public async Task<bool> UpdateAsync(User user, CancellationToken cancellationToken = default)
        {
            context.Users.Update(user);

            return await context.SaveChangesAsync(cancellationToken) > 0;
        }

        /// <summary>
        /// Асинхронно удаляет сущность <see cref="User"/> из базы данных, установив свойство <see cref="User.IsDeleted"/> в TRUE.
        /// </summary>
        /// <param name="user">Пользователь для удаления.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Результат задачи содержит булевое значение, указывающее, были ли сохранены какие-либо изменения.</returns>
        public async Task<bool> DeleteAsync(User user, CancellationToken cancellationToken = default)
        {
            return await UpdateAsync(user, cancellationToken);
        }
    }
}