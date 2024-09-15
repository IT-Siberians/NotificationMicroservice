using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NotificationMicroservice.Domain.Entities;
using NotificationMicroservice.Domain.ValueObjects;

namespace NotificationMicroservice.DataAccess.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id);

            builder.Property(x => x.Username)
                .HasMaxLength(User.MAX_USERNAME_LENGTH)
                .HasConversion(
                    v => v.Value,
                    v => new Username(v))
                .IsRequired();

            builder.Property(x => x.FullName)
                .IsRequired();

            builder.Property(x => x.Email)
                .HasConversion(
                    v => v.Value,
                    v => new Email(v))
                .IsRequired();

            builder.Property(x => x.CreationDate)
                .IsRequired();

            builder.HasMany<MessageType>()
                .WithOne(x => x.CreatedByUser);

            builder.HasMany<MessageType>()
                .WithOne(x => x.ModifiedByUser);

            builder.HasMany<MessageTemplate>()
                .WithOne(x => x.CreatedByUser);

            builder.HasMany<MessageTemplate>()
                .WithOne(x => x.ModifiedByUser);

        }
    }
}
