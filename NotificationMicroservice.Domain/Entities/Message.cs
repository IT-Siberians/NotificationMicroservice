using NotificationMicroservice.Domain.Entities.Base;
using NotificationMicroservice.Domain.Enums;
using NotificationMicroservice.Domain.Exception.Message;
using NotificationMicroservice.Domain.Helpers;

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
        public const int MAX_DIRECTION_LENGTH = 10;

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
        public Direction Direction { get; }

        /// <summary>
        /// Дата отправки сообщения
        /// </summary>
        public DateTime CreationDate { get; }

        /// <summary>
        /// Пустой конструктор для EF Core
        /// </summary>
#pragma warning disable CS8618
        protected Message() { }
#pragma warning disable CS8618

        /// <summary>
        /// Основной конструктор класса
        /// </summary>
        /// <param name="type">сущность типа сообщения</param>
        /// <param name="text">текст сообщения</param>
        /// <param name="direction">отправление отправки сообщения</param>
        /// <param name="creationDate">дата и время отправки сообщения</param>
        /// <exception cref="MessageTextNullOrEmptyException"></exception>
        public Message(MessageType type, string text, Direction direction, DateTime creationDate)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                throw new MessageTextNullOrEmptyException(ExceptionMessages.ERROR_TEXT, text);
            }

            Type = type;
            Text = text;
            Direction = direction;
            CreationDate = creationDate;
        }
    }
}
