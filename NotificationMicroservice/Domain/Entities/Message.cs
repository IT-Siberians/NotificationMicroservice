namespace NotificationMicroservice.Domain.Entities
{
    /// <summary>
    /// Сообщение
    /// </summary>
    public class Message
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id {  get; private set; }
        
        /// <summary>
        /// Тип сообщения
        /// </summary>
        public Guid MessageType { get; private set; }
        
        /// <summary>
        /// Сообщение
        /// </summary>
        public string MessageText {  get; private set; }
        
        /// <summary>
        /// Напрвление отправки
        /// </summary>
        public string Direction { get; private set; }
        
        /// <summary>
        /// Дата отправки сообщения
        /// </summary>
        public DateTime CreatedDate { get; private set; }

        public Message( Guid id, Guid messageType, string messageText, string direction, DateTime createDate)
        { 
            Id = id;
            MessageType = messageType;
            MessageText = messageText;
            Direction = direction;
            CreatedDate = createDate;
        }
    }
}
