namespace NotificationMicroservice.Application.Model.Template
{
    public class EditTemplateModel
    {
        public Guid Id { get; set; }
        public Guid MessageTypeId { get; init; }
        public string Language { get; init; }
        public string Template { get; init; }
        public bool IsRemoved { get; init; }
        public Guid ModifiedUserId { get; init; }
    }
}
