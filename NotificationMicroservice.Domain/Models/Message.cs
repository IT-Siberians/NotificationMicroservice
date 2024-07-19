using NotificationMicroservice.Domain.Interfaces.Model;
using System.Text;

namespace NotificationMicroservice.Domain.Models
{
    /// <summary>
    /// Сообщение
    /// </summary>
    public class Message : IEntity<Guid>
    {
        /// <summary>
        /// Длинна строки описывающий направление отправки
        /// </summary>
        public const int MAX_DIRECTION_LENG = 10;

        private Guid _id;
        private MessageType _messageType;
        private string _messageText;
        private string _direction;
        private DateTime _createDate;

        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get => _id; }

        /// <summary>
        /// Тип сообщения
        /// </summary>
        public MessageType MessageType { get => _messageType; }

        /// <summary>
        /// Сообщение
        /// </summary>
        public string MessageText { get => _messageText; }

        /// <summary>
        /// Напрвление отправки
        /// </summary>
        public string Direction { get => _direction; }

        /// <summary>
        /// Дата отправки сообщения
        /// </summary>
        public DateTime CreateDate { get => _createDate; }

        public Message() { }

        /// <summary>
        /// Основной конструктор класса
        /// </summary>
        private Message(Guid id, MessageType messageType, string messageText, string direction, DateTime createDate)
        {
            _id = id;
            _messageType = messageType;
            _messageText = messageText;
            _direction = direction;
            _createDate = createDate;
        }

        /// <summary>
        /// Cоздание сообщения
        /// </summary>
        /// <param name="id">идентификатор записи</param>
        /// <param name="messageType">сущность типа сообщения</param>
        /// <param name="messageText">текст сообщения</param>
        /// <param name="direction">отправление отправки сообщения</param>
        /// <param name="createDate">дата и время отправки сообщения</param>
        /// <returns>Кортеж (Сущность, Ошибки)</returns>
        public (Message Message, string Error) Create(Guid id, MessageType messageType, string messageText, string direction, DateTime createDate)
        {
            var errorSb = new StringBuilder();

            if (id == Guid.Empty)
            {
                errorSb.AppendLine($"Identifier {id} cannot be empty");
            }

            if (string.IsNullOrEmpty(messageText))
            {
                errorSb.AppendLine($"Message text cannot be empty");
            }

            if (string.IsNullOrEmpty(direction) || direction.Length > MAX_DIRECTION_LENG)
            {
                errorSb.AppendLine($"Direction cannot be empty");
            }

            return (new Message(id, messageType, messageText, direction, createDate), errorSb.ToString());
        }

    }
}
