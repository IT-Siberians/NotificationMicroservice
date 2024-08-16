namespace NotificationMicroservice.Domain.Exception.MessageType
{
    /// <summary>
    /// Исключение пустого значения идентификатора
    /// </summary>
    public class MessageTypeGuidEmptyException : ArgumentException
    {
        /// <summary>
        /// Конструктор с информационным сообщением и значением параметра
        /// </summary>
        /// <param name="message">Информационное сообщение</param>
        /// <param name="value">значение параметра вызвашвего исключение</param>
        public MessageTypeGuidEmptyException(string? message, string? value)
            : base(message, value)
        {
        }
    }
}