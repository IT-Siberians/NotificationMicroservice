using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NotificationMicroservice.Domain.Entities;
using NotificationMicroservice.Domain.Enums;
using NotificationMicroservice.Domain.ValueObjects;

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
                .HasConversion(
                    o => o.ToString(),
                    s => (Language)Enum.Parse(typeof(Language), s))
                .IsRequired();

            builder.Property(x => x.Template)
                .HasMaxLength(MessageTemplate.TEMPLATE_MAX_LENGTH)
                .HasConversion(
                    o => o.Value,
                    s => new Template(s))
                .IsRequired();

            builder.Property(x => x.IsRemoved)
                .IsRequired();

            builder.Property(x => x.CreationDate)
                .IsRequired();

            builder.Property(x => x.ModificationDate)
                .IsRequired(false);

            builder.HasOne(x => x.Type)
                .WithMany();

            builder.Navigation(x => x.Type)
                .AutoInclude();

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
