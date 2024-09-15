using NotificationMicroservice.Application.Model.Type;

namespace NotificationMicroservice.Application.Model.Message
{
    public class MessageModel : IBaseModel<Guid>
    {
        public Guid Id { get; init; }
        public string MessageText { get; init; } = string.Empty;
        public string Direction { get; init; } = string.Empty;
        public DateTime CreationDate { get; init; }
        public TypeModel Type { get; init; } = new TypeModel();
    }
}
