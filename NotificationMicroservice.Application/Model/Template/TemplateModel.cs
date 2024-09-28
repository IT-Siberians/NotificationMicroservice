using NotificationMicroservice.Application.Model.Abstractions;
using NotificationMicroservice.Application.Model.Type;
using NotificationMicroservice.Application.Model.User;

namespace NotificationMicroservice.Application.Model.Template
{
    public class TemplateModel : IBaseModel<Guid>
    {
        public Guid Id { get; init; }
        public string Language { get; init; } = string.Empty;
        public string Template { get; init; } = string.Empty;
        public bool IsRemoved { get; init; }
        public UserModel CreatedByUser { get; init; } = new UserModel();
        public DateTime CreationDate { get; init; }
        public UserModel? ModifiedByUser { get; init; } = new UserModel();
        public DateTime? ModificationDate { get; init; }
        public TypeModel Type { get; init; } = new TypeModel();
    }
}