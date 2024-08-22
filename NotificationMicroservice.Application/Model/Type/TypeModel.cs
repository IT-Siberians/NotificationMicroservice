namespace NotificationMicroservice.Application.Model.Type
{
    public class TypeModel
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public bool IsRemove { get; init; }
        public string CreateUserName { get; init; }
        public DateTime CreateDate { get; init; }
        public string? ModifyUserName { get; init; }
        public DateTime? ModifyDate { get; init; }
    }
}
