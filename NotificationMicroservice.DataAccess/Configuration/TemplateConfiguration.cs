using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NotificationMicroservice.Domain.Entity;

namespace NotificationMicroservice.DataAccess.Configuration
{
    internal class TemplateConfiguration : IEntityTypeConfiguration<MessageTemplate>
    {
        public void Configure(EntityTypeBuilder<MessageTemplate> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Language)
                .HasMaxLength(MessageTemplate.LANGUAGE_LENG)
                .IsRequired();

            builder.Property(x => x.Template)
                .IsRequired();

            builder.Property(x => x.IsRemove)
                .IsRequired();

            builder.Property(x => x.CreateUserName)
                .IsRequired();

            builder.Property(x => x.CreateDate)
                .IsRequired();

            builder.Property(x => x.ModifyUserName)
                .IsRequired(false);

            builder.Property(x => x.ModifyDate)
                .IsRequired(false);

            builder.HasOne(x => x.Type)
                .WithMany();

            builder.Navigation(x => x.Type)
                .AutoInclude();

        }
    }
}
