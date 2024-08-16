namespace NotificationMicroservice.Domain.Exception.MessageType
{
    /// <summary>
    /// Исключение нарушение ограничений длинны названия 
    /// </summary>
    public class MessageTypeNameLengthException : ArgumentException
    {
        /// <summary>
        /// Конструктор с информационным сообщением и значением параметра
        /// </summary>
        /// <param name="message">Информационное сообщение</param>
        /// <param name="value">значение параметра вызвашвего исключение</param>
        public MessageTypeNameLengthException(string? message, string? value)
            : base(message, value)
        {
        }
    }
}