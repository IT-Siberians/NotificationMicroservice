namespace NotificationMicroservice.Application.Model.Template
{
    public class UpdateTemplateModel : IBaseModel<Guid>
    {
        public Guid Id { get; set; }
        public Guid MessageTypeId { get; init; }
        public string Language { get; init; } = string.Empty;
        public string Template { get; init; } = string.Empty;
        public bool IsRemoved { get; init; }
        public Guid ModifiedByUserId { get; init; }
    }
}
