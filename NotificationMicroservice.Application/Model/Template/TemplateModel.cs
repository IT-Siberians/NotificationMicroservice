using NotificationMicroservice.Application.Model.Type;
using NotificationMicroservice.Application.Model.User;

namespace NotificationMicroservice.Application.Model.Template
{
    public class TemplateModel
    {
        public Guid Id { get; init; }
        public string Language { get; init; }
        public string Template { get; init; }
        public bool IsRemoved { get; init; }
        public UserModel CreatedUser { get; init; } = new UserModel();
        public DateTime CreationDate { get; init; }
        public UserModel? ModifiedUser { get; init; } = new UserModel();
        public DateTime? ModifiedDate { get; init; }
        public TypeModel Type { get; init; } = new TypeModel();
    }
}