using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NotificationMicroservice.Domain.Entities;
using NotificationMicroservice.Domain.ValueObjects;

namespace NotificationMicroservice.DataAccess.Configuration
{
    public class BusQueueConfiguration : IEntityTypeConfiguration<BusQueue>
    {
        public void Configure(EntityTypeBuilder<BusQueue> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.QueueName)
                .HasConversion(
                    o => o.Value,
                    s => new QueueName(s))
                .IsRequired();

            builder.Property(x => x.IsRemoved)
                .IsRequired();

            builder.HasOne(x => x.Type)
                .WithMany();

            builder.Navigation(x => x.Type)
                .AutoInclude();

            builder.Property(x => x.CreationDate)
                .IsRequired();

            builder.Property(e => e.ModificationDate)
                .IsRequired(false);

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
