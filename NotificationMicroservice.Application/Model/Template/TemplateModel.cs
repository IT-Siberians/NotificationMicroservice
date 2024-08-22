using NotificationMicroservice.Application.Model.Type;

namespace NotificationMicroservice.Application.Model.Template
{
    public class TemplateModel
    {
        public Guid Id { get; init; }
        public string Language { get; init; }
        public string Template { get; init; }
        public bool IsRemove { get; init; }
        public string CreateUserName { get; init; }
        public DateTime CreateDate { get; init; }
        public string? ModifyUserName { get; init; }
        public DateTime? ModifyDate { get; init; }
        public TypeModel Type { get; set; } = new TypeModel();
    }
}