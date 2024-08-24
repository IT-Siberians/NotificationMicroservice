using NotificationMicroservice.Application.Model.Type;

namespace NotificationMicroservice.Application.Model.Template
{
    public class TemplateModel
    {
        public Guid Id { get; init; }
        public string Language { get; init; }
        public string Template { get; init; }
        public bool IsRemoved { get; init; }
        public string CreatedUserName { get; init; }
        public DateTime CreatedDate { get; init; }
        public string? ModifiedUserName { get; init; }
        public DateTime? ModifiedDate { get; init; }
        public TypeModel Type { get; set; } = new TypeModel();
    }
}