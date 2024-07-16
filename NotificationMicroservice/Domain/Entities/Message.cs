﻿namespace NotificationMicroservice.Domain.Entities
{
    /// <summary>
    /// Сообщение
    /// </summary>
    public class Message<T>
    {
        private T _id;
        private T _messageType;
        private string _messageText;
        private string _direction;
        private DateTime _createdDate;

        /// <summary>
        /// Идентификатор
        /// </summary>
        public T Id { get => _id; }

        /// <summary>
        /// Тип сообщения
        /// </summary>
        public T MessageType { get => _messageType; }

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
        public DateTime CreatedDate { get => _createdDate; }

        public Message(T id, T messageType, string messageText, string direction, DateTime createDate)
        {
            _id = id;
            _messageType = messageType;
            _messageText = messageText;
            _direction = direction;
            _createdDate = createDate;
        }
        public void NewMessage(T messageType, string messageText, string direction, DateTime createDate)
        {
            _messageType = messageType;
            _messageText = messageText;
            _direction = direction;
            _createdDate = createDate;
        }
    }
}
