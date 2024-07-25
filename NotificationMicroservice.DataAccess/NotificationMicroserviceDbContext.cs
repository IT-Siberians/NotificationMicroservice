using Microsoft.EntityFrameworkCore;
using NotificationMicroservice.DataAccess.Entities;

namespace NotificationMicroservice.DataAccess
{
    public class NotificationMicroserviceDbContext : DbContext
    {
        public NotificationMicroserviceDbContext(DbContextOptions<NotificationMicroserviceDbContext> options)
            : base(options)
        {
        }

        public DbSet<TemplateEntity> Templates { get; set; }
        public DbSet<TypeEntity> Types { get; set; }
        public DbSet<MessageEntity> Messages { get; set; }
    }
}
