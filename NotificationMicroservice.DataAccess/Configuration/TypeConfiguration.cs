using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NotificationMicroservice.Domain.Entity;

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
                .HasMaxLength(MessageType.MAX_NAME_LENG)
                .IsRequired();

            builder.Property(x => x.CreateUserName)
                .IsRequired();

            builder.Property(x => x.CreateDate)
                .IsRequired();

            builder.Property(e => e.ModifyUserName)
                  .IsRequired(false);

            builder.Property(e => e.ModifyDate)
                  .IsRequired(false);

            //builder.HasMany<Message>()
            //    .WithOne(x => x.Type);

            //builder.HasMany<MessageTemplate>()
            //    .WithOne(x => x.Type);

        }
    }
}
