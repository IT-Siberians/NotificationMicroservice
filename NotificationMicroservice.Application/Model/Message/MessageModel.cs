using NotificationMicroservice.Application.Model.Type;

namespace NotificationMicroservice.Application.Model.Message
{
    public class MessageModel
    {
        public Guid Id { get; init; }
        public string MessageText { get; init; }
        public string Direction { get; init; }
        public DateTime CreatedDate { get; init; }
        public TypeModel Type { get; set; } = new TypeModel();
    }
}
