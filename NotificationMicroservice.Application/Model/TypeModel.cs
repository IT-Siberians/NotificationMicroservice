namespace NotificationMicroservice.Application.Model
{
    public class TypeModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsRemove { get; set; }
        public string CreateUserName { get; set; } = string.Empty;
        public DateTime CreateDate { get; set; }
        public string? ModifyUserName { get; set; }
        public DateTime? ModifyDate { get; set; }
    }
}
