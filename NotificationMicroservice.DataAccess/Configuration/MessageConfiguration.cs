using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NotificationMicroservice.Domain.Entities;

namespace NotificationMicroservice.DataAccess.Configuration
{
    internal class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Text)
                .IsRequired();

            builder.Property(x => x.Direction)
                .IsRequired();

            builder.Property(x => x.CreationDate)
                .IsRequired();

            builder.HasOne(x => x.Type)
                .WithMany()
                .IsRequired();

            builder.Navigation(x => x.Type)
                .AutoInclude();
        }
    }
}
