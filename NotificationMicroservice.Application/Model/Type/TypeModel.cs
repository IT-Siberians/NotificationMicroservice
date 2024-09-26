using NotificationMicroservice.Application.Model.User;

namespace NotificationMicroservice.Application.Model.Type
{
    public class TypeModel : IBaseModel<Guid>
    {
        public Guid Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public bool IsRemoved { get; init; }
        public UserModel CreatedByUser { get; init; } = new UserModel();
        public DateTime CreationDate { get; init; }
        public UserModel? ModifiedByUser { get; init; } = new UserModel();
        public DateTime? ModificationDate { get; init; }
    }
}
