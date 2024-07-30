namespace NotificationMicroservice.Domain.Exception.MessageType
{
    /// <summary>
    /// Исключение нарушение ограничений длинны названия 
    /// </summary>
    public class MessageTypeNameLengthException : ArgumentException
    {
        /// <summary>
        /// Основной конструктор
        /// </summary>
        public MessageTypeNameLengthException()
        {
        }

        /// <summary>
        /// Конструктор с информационным сообщением и значением параметра
        /// </summary>
        /// <param name="message">Информационное сообщение</param>
        /// <param name="value">значение параметра вызвашвего исключение</param>
        public MessageTypeNameLengthException(string? message, string? value)
            : base(message, value)
        {
        }

        /// <summary>
        /// Конструктор с информационным сообщением и исключением 
        /// </summary>
        /// <param name="message">Информационное сообщение</param>
        /// <param name="innerException">Внутренне исключение</param>
        public MessageTypeNameLengthException(string? message, ArgumentException? innerException) 
            : base(message, innerException)
        {
        }
    }
}