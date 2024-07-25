using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NotificationMicroservice.DataAccess.Entities;

namespace NotificationMicroservice.DataAccess.Configuration
{
    internal class TemplateConfiguration : IEntityTypeConfiguration<TemplateEntity>
    {
        public void Configure(EntityTypeBuilder<TemplateEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.TypeId)
                .IsRequired();

            builder.Property(x => x.Language)
                .IsRequired();

            builder.Property(x => x.Template)
                .IsRequired();

            builder.Property(x => x.IsRemove)
                .IsRequired();

            builder.Property(x => x.CreateUserName)
                .IsRequired();

            builder.Property(x => x.CreateDate)
                .IsRequired();

            builder.Property(x => x.ModifyUserName);

            builder.Property(x => x.ModifyDate);

            builder.HasOne(x => x.Type)
            .WithMany(c => c.Templates)
            .HasForeignKey(x => x.TypeId);

        }
    }
}
