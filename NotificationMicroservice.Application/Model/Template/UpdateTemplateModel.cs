using NotificationMicroservice.Application.Model.Abstractions;

namespace NotificationMicroservice.Application.Model.Template
{
    public class UpdateTemplateModel : IBaseModel<Guid>
    {
        public Guid Id { get; set; }
        public required Guid MessageTypeId { get; init; }
        public required string Language { get; init; } = string.Empty;
        public required string Template { get; init; } = string.Empty;
        public required bool IsRemoved { get; init; }
        public required Guid ModifiedByUserId { get; init; }
    }
}
