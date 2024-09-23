using NotificationMicroservice.Application.Model.Type;
using NotificationMicroservice.Domain.Enums;

namespace NotificationMicroservice.Application.Model.Message
{
    public class MessageModel : IBaseModel<Guid>
    {
        public Guid Id { get; init; }
        public string Text { get; init; } = string.Empty;
        public Direction Direction { get; init; }
        public DateTime CreationDate { get; init; }
        public TypeModel Type { get; init; } = new TypeModel();
    }
}
