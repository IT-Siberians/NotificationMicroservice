namespace NotificationMicroservice.Application.Model
{
    public class TemplateModel
    {
        public Guid Id { get; set; }
        public string Language { get; set; } = string.Empty;
        public string Template { get; set; } = string.Empty;
        public bool IsRemove { get; set; }
        public string CreateUserName { get; set; } = string.Empty;
        public DateTime CreateDate { get; set; }
        public string? ModifyUserName { get; set; }
        public DateTime? ModifyDate { get; set; }
        public TypeModel Type { get; set; } = new TypeModel();
    }
}