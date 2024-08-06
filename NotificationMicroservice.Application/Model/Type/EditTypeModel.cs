namespace NotificationMicroservice.Application.Model.Type
{
    public class EditTypeModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ModifyUserName { get; set; } = string.Empty;
    }
}
