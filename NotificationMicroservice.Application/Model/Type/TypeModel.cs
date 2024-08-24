namespace NotificationMicroservice.Application.Model.Type
{
    public class TypeModel
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public bool IsRemoved { get; init; }
        public string CreatedUserName { get; init; }
        public DateTime CreatedDate { get; init; }
        public string? ModifiedUserName { get; init; }
        public DateTime? ModifiedDate { get; init; }
    }
}
