namespace NotificationMicroservice.Application.Model.Template
{
    public class EditTemplateModel
    {
        public Guid Id { get; set; }
        public Guid MessageTypeId { get; set; } = Guid.Empty;
        public string Language { get; set; } = string.Empty;
        public string Template { get; set; } = string.Empty;
        public bool IsRemove { get; set; }
        public string ModifyUserName { get; set; } = string.Empty;
    }
}
