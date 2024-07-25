using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NotificationMicroservice.DataAccess.Entities;
using NotificationMicroservice.Domain.Models;

namespace NotificationMicroservice.DataAccess.Configuration
{
    public class TypeConfiguration : IEntityTypeConfiguration<TypeEntity>
    {
        public void Configure(EntityTypeBuilder<TypeEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasMaxLength(MessageType.MAX_NAME_LENG)
                .IsRequired();

            builder.Property(x => x.CreateUserName)
                .IsRequired();

            builder.Property(x => x.CreateDate)
                .IsRequired();

            builder.Property(x => x.ModifyUserName);

            builder.Property(x => x.ModifyDate);

        }
    }
}
