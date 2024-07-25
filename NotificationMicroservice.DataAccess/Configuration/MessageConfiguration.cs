using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NotificationMicroservice.DataAccess.Entities;

namespace NotificationMicroservice.DataAccess.Configuration
{
    internal class MessageConfiguration : IEntityTypeConfiguration<MessageEntity>
    {
        public void Configure(EntityTypeBuilder<MessageEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.TypeId)
                .IsRequired();

            builder.Property(x => x.MessageText)
                .IsRequired();

            builder.Property(x => x.Direction)
                .IsRequired();

            builder.Property(x => x.CreateDate)
                .IsRequired();

            builder.HasOne(x => x.Type)
            .WithMany(c => c.Messages)
            .HasForeignKey(x => x.TypeId);
        }
    }
}
