namespace NotificationMicroservice.Application.Model.Type
{
    public class EditTypeModel
    {
        public Guid Id { get; set; }
        public string Name { get; init; }
        public string ModifiedUserName { get; init; }
    }
}
