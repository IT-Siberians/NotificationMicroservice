namespace NotificationMicroservice.Application.Model.Type
{
    public class UpdateTypeModel : IBaseModel<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; init; } = string.Empty;
        public Guid ModifiedByUserId { get; init; }
    }
}
