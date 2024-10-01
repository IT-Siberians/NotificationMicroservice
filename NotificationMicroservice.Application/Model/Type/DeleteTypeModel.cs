using NotificationMicroservice.Application.Model.Abstractions;

namespace NotificationMicroservice.Application.Model.Type
{
    public class DeleteTypeModel : IBaseModel<Guid>
    {
        public Guid Id { get; set; }
        public required Guid ModifiedByUserId { get; init; }
    }
}
