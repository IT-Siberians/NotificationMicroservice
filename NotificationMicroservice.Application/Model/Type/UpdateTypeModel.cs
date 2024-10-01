using NotificationMicroservice.Application.Model.Abstractions;

namespace NotificationMicroservice.Application.Model.Type
{
    public class UpdateTypeModel : IBaseModel<Guid>
    {
        public Guid Id { get; set; }
        public required string Name { get; init; } = string.Empty;
        public required Guid ModifiedByUserId { get; init; }
    }
}
