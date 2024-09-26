using Microsoft.EntityFrameworkCore;
using NotificationMicroservice.DataAccess.Repository.Abstractions;
using NotificationMicroservice.Domain.Entities;

namespace NotificationMicroservice.DataAccess.Repository
{
    /// <summary>
    /// Представляет репозиторий для управления сущностями <see cref="User"/> в базе данных.
    /// Реализует интерфейс <see cref="IUserRepository"/>.
    /// </summary>
    /// <param name="context">Контекст базы данных.</param>
    public class UserRepository(NotificationMicroserviceDbContext context) : IUserRepository
    {
        /// <summary>
        /// Асинхронно получает все сущности <see cref="User"/> из базы данных.
        /// </summary>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <param name="asNoTracking">Опционально. Если TRUE, возвращенные сущности не будут отслеживаться Entity Framework Core.</param>
        /// <returns>Результат задачи содержит список пользователей.</returns>
        public async Task<IEnumerable<User>> GetAllAsync(CancellationToken cancellationToken, bool asNoTracking = false)
        {
            return await (asNoTracking ? context.Users.AsNoTracking() : context.Users)
                .ToListAsync(cancellationToken);
        }

        /// <summary>
        /// Асинхронно получает единственную сущность <see cref="User"/> по ее <see cref="User.Id"/>.
        /// </summary>
        /// <param name="id">Идентификатор пользователя для получения.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Результат задачи содержит полученного пользователя или NULL, если не найдено.</returns>
        public async Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        /// <summary>
        /// Асинхронно добавляет новую сущность <see cref="User"/> в базу данных и возвращает сгенерированный <see cref="User.Id"/>.
        /// </summary>
        /// <param name="user">Пользователь для добавления.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Результат задачи содержит сгенерированный ID добавленного пользователя.</returns>
        public async Task<Guid> AddAsync(User user, CancellationToken cancellationToken)
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
        public async Task<bool> UpdateAsync(User user, CancellationToken cancellationToken)
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
        public async Task<bool> DeleteAsync(User user, CancellationToken cancellationToken)
        {
            return await UpdateAsync(user, cancellationToken);
        }
    }
}