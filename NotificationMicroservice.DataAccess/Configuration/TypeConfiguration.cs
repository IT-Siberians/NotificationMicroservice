using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NotificationMicroservice.Domain.Entities;
using NotificationMicroservice.Domain.ValueObjects;

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
                .HasConversion(
                    v => v.Value,
                    v => new TypeName(v))
                .IsRequired();

            builder.Property(x => x.IsRemoved)
                .IsRequired();

            builder.Property(x => x.CreationDate)
                .IsRequired();

            builder.Property(e => e.ModificationDate)
                .IsRequired(false);

            builder.HasMany<Message>()
                .WithOne(x => x.Type);

            builder.HasMany<MessageTemplate>()
                .WithOne(x => x.Type);

            builder.HasMany<BusQueue>()
                .WithOne(p => p.Type);

            builder.HasOne(x => x.CreatedByUser)
                .WithMany()
                .IsRequired();

            builder.Navigation(x => x.CreatedByUser)
                .AutoInclude();

            builder.HasOne(x => x.ModifiedByUser)
                .WithMany()
                .IsRequired(false);

            builder.Navigation(x => x.ModifiedByUser)
                .AutoInclude();
        }
    }
}
