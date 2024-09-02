using NotificationMicroservice.Application.Model.User;

namespace NotificationMicroservice.Application.Model.Type
{
    public class TypeModel
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public bool IsRemoved { get; init; }
        public UserModel CreatedUser { get; init; } = new UserModel();
        public DateTime CreationDate { get; init; }
        public UserModel? ModifiedUser { get; init; } = new UserModel();
        public DateTime? ModifiedDate { get; init; }
    }
}
