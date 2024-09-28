using NotificationMicroservice.Domain.Entities.Base;
using NotificationMicroservice.Domain.Enums;
using NotificationMicroservice.Domain.Exception.Message;
using NotificationMicroservice.Domain.ValueObjects;

namespace NotificationMicroservice.Domain.Entities
{
    /// <summary>
    /// Сообщение
    /// </summary>
    public class Message : IEntity<Guid>
    {
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
        public MessageText Text { get; }

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
        public Message(MessageType type, MessageText text, Direction direction, DateTime creationDate)
        {
            Type = type;
            Text = text;
            Direction = direction;
            CreationDate = creationDate;
        }
    }
}
