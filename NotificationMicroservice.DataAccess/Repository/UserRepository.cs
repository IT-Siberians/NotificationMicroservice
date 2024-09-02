using NotificationMicroservice.DataAccess.Repository.Abstractions;
using NotificationMicroservice.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace NotificationMicroservice.DataAccess.Repository
{
    public class UserRepository(NotificationMicroserviceDbContext context) : IUserRepository
    {
        public async Task<IEnumerable<User>> GetAllAsync(CancellationToken cancellationToken, bool asNoTracking = false)
        {
            return await (asNoTracking ? context.Users.AsNoTracking() : context.Users)
                .ToListAsync(cancellationToken);
        }

        public async Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task<Guid> AddAsync(User entity, CancellationToken cancellationToken)
        {
            context.Users.Add(entity);

            await context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }

        public async Task<bool> UpdateAsync(User entity, CancellationToken cancellationToken)
        {
            context.Users.Update(entity);

            return await context.SaveChangesAsync(cancellationToken) == 1;
        }

        public async Task<bool> DeleteAsync(User entity, CancellationToken cancellationToken)
        {
            return await UpdateAsync(entity, cancellationToken); 
        }
    }
}
