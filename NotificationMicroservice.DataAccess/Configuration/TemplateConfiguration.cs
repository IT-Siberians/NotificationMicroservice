using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NotificationMicroservice.Domain.Entities;

namespace NotificationMicroservice.DataAccess.Configuration
{
    public class TemplateConfiguration : IEntityTypeConfiguration<MessageTemplate>
    {
        public void Configure(EntityTypeBuilder<MessageTemplate> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Language)
                .HasMaxLength(MessageTemplate.LANGUAGE_LENGTH)
                .IsRequired();

            builder.Property(x => x.Template)
                .IsRequired();

            builder.Property(x => x.IsRemoved)
                .IsRequired();

            builder.Property(x => x.CreationDate)
                .IsRequired();

            builder.Property(x => x.ModifiedDate)
                .IsRequired(false);

            builder.HasOne(x => x.Type)
                .WithMany();

            builder.Navigation(x => x.Type)
                .AutoInclude();

            builder.HasOne(x => x.CreatedUser)
                .WithMany();

            builder.Navigation(x => x.CreatedUser)
                .AutoInclude();

            builder.HasOne(x => x.ModifiedUser)
                .WithMany();

            builder.Navigation(x => x.ModifiedUser)
                .AutoInclude();
        }
    }
}
