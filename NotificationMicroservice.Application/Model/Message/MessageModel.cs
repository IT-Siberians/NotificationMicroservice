using NotificationMicroservice.Application.Model.Type;

namespace NotificationMicroservice.Application.Model.Message
{
    public class MessageModel
    {
        public Guid Id { get; set; }
        public string MessageText { get; set; } = string.Empty;
        public string Direction { get; set; } = string.Empty;
        public DateTime CreateDate { get; set; }
        public TypeModel Type { get; set; } = new TypeModel();
    }
}
