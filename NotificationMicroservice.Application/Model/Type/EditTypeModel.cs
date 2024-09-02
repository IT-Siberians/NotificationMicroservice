namespace NotificationMicroservice.Application.Model.Type
{
    public class EditTypeModel
    {
        public Guid Id { get; set; }
        public string Name { get; init; }
        public Guid ModifiedUserId { get; init; }
    }
}
