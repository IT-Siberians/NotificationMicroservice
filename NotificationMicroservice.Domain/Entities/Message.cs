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

        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Тип сообщения
        /// </summary>
        public MessageType Type { get; }

        /// <summary>
        /// Сообщение
        /// </summary>
        public string Text { get; }

        /// <summary>
        /// Напрвление отправки
        /// </summary>
        public string Direction { get; }

        /// <summary>
        /// Дата отправки сообщения
        /// </summary>
        public DateTime CreateDate { get; }

        /// <summary>
        /// Пустой конструктор для EF Core
        /// </summary>
        protected Message() { }

        /// <summary>
        /// Основной конструктор класса
        /// </summary>
        /// <param name="id">идентификатор записи</param>
        /// <param name="type">сущность типа сообщения</param>
        /// <param name="text">текст сообщения</param>
        /// <param name="direction">отправление отправки сообщения</param>
        /// <param name="createDate">дата и время отправки сообщения</param>
        /// <exception cref="MessageGuidEmptyException"></exception>
        /// <exception cref="MessageTextNullOrEmptyException"></exception>
        /// <exception cref="MessageDirectionNullOrEmptyException"></exception>
        /// <exception cref="MessageDirectionLengthException"></exception>
        public Message(Guid id, MessageType type, string text, string direction, DateTime createDate)
        {
            if (id == Guid.Empty)
            {
                throw new MessageGuidEmptyException(ExceptionString.ERROR_ID, id.ToString());
            }

            if (string.IsNullOrWhiteSpace(text))
            {
                throw new MessageTextNullOrEmptyException(ExceptionString.ERROR_TEXT, text);
            }

            if (string.IsNullOrWhiteSpace(direction))
            {
                throw new MessageDirectionNullOrEmptyException(ExceptionString.ERROR_DIRECTION, direction);

            }

            if (direction.Length > MAX_DIRECTION_LENG)
            {
                throw new MessageDirectionLengthException(ExceptionString.ERROR_DIRECTION_LENG, direction.Length.ToString());
            }

            Id = id;
            Type = type;
            Text = text;
            Direction = direction;
            CreateDate = createDate;
        }
    }
}
