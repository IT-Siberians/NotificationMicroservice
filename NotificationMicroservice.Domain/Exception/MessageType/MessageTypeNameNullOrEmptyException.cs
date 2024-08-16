namespace NotificationMicroservice.Domain.Exception.MessageType
{
    /// <summary>
    /// Исключение пустого значения названия
    /// </summary>
    public class MessageTypeNameNullOrEmptyException : ArgumentNullException
    {
        /// <summary>
        /// Конструктор с информационным сообщением и значением параметра
        /// </summary>
        /// <param name="message">Информационное сообщение</param>
        /// <param name="value">значение параметра вызвашвего исключение</param>
        public MessageTypeNameNullOrEmptyException(string? message, string? value) 
            : base(value, message)
        {
        }
    }
}