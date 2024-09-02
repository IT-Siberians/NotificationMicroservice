using Microsoft.EntityFrameworkCore;
using NotificationMicroservice.Domain.Entities;

namespace NotificationMicroservice.DataAccess
{
    public class NotificationMicroserviceDbContext : DbContext
    {
        public DbSet<MessageTemplate> Templates { get; set; }
        public DbSet<MessageType> Types { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<User> Users { get; set; }

        public NotificationMicroserviceDbContext(DbContextOptions<NotificationMicroserviceDbContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }        
    }
}
