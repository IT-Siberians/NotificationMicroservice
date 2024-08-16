using NotificationMicroservice.Domain.Exception.Message;
using NotificationMicroservice.Domain.Exception.Helpers;
using NotificationMicroservice.Domain.Entities.Base;

namespace NotificationMicroservice.Domain.Entities
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

        /// <summary>
        /// Основной конструктор класса
        /// </summary>
        /// <param name="id">идентификатор записи</param>
        /// <param name="messageType">сущность типа сообщения</param>
        /// <param name="messageText">текст сообщения</param>
        /// <param name="direction">отправление отправки сообщения</param>
        /// <param name="createDate">дата и время отправки сообщения</param>
        /// <exception cref="MessageGuidEmptyException"></exception>
        /// <exception cref="MessageTextNullOrEmptyException"></exception>
        /// <exception cref="MessageDirectionNullOrEmptyException"></exception>
        /// <exception cref="MessageDirectionLengthException"></exception>
        public Message(Guid id, MessageType messageType, string messageText, string direction, DateTime createDate)
        {
            if (id == Guid.Empty)
            {
                throw new MessageGuidEmptyException(ExceptionStrings.ERROR_ID, id.ToString());
            }

            if (string.IsNullOrWhiteSpace(messageText))
            {
                throw new MessageTextNullOrEmptyException(ExceptionStrings.ERROR_TEXT, messageText);
            }

            if (string.IsNullOrWhiteSpace(direction))
            {
                throw new MessageDirectionNullOrEmptyException(ExceptionStrings.ERROR_DIRECTION, direction);
            }

            if (direction.Length > MAX_DIRECTION_LENG)
            {
                throw new MessageDirectionLengthException(ExceptionStrings.ERROR_DIRECTION_LENG, direction.Length.ToString());
            }

            _id = id;
            _messageType = messageType;
            _messageText = messageText;
            _direction = direction;
            _createDate = createDate;
        }
    }
}
