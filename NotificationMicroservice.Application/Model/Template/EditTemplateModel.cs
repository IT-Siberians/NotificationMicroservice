namespace NotificationMicroservice.Application.Model.Template
{
    public class EditTemplateModel
    {
        public Guid Id { get; init; }
        public Guid MessageTypeId { get; init; }
        public string Language { get; init; }
        public string Template { get; init; }
        public bool IsRemove { get; init; }
        public string ModifyUserName { get; init; }
    }
}
