using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NotificationMicroservice.Domain.Entities;

namespace NotificationMicroservice.DataAccess.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id);

            builder.Property(x => x.UserName)
                .IsRequired();

            builder.Property(x => x.FullName)
                .IsRequired();

            builder.Property(x => x.Email)
                .IsRequired();

            builder.Property(x => x.CreationDate)
                .IsRequired();

            builder.HasMany<MessageType>()
                .WithOne(x => x.CreatedUser);

            builder.HasMany<MessageType>()
                .WithOne(x => x.ModifiedUser);

            builder.HasMany<MessageTemplate>()
                .WithOne(x => x.CreatedUser);

            builder.HasMany<MessageTemplate>()
                .WithOne(x => x.ModifiedUser);

        }
    }
}
