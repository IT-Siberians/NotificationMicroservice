using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NotificationMicroservice.Domain.Entities;

namespace NotificationMicroservice.DataAccess.Configuration
{
    public class TypeConfiguration : IEntityTypeConfiguration<MessageType>
    {
        public void Configure(EntityTypeBuilder<MessageType> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                .HasMaxLength(MessageType.MAX_NAME_LENGTH)
                .IsRequired();

            builder.Property(x => x.IsRemoved)
                .IsRequired();

            builder.Property(x => x.CreatedUserName)
                .IsRequired();

            builder.Property(x => x.CreatedDate)
                .IsRequired();

            builder.Property(e => e.ModifiedUserName)
                .IsRequired(false);

            builder.Property(e => e.ModifiedDate)
                .IsRequired(false);

            builder.HasMany<Message>()
                .WithOne(x => x.Type);

            builder.HasMany<MessageTemplate>()
                .WithOne(x => x.Type);

        }
    }
}
