namespace NotificationMicroservice.Domain.Exception.MessageType
{
    /// <summary>
    /// Исключение пустого значения пользоватля
    /// </summary>
    public class MessageTypeUserNameNullOrEmptyException : ArgumentNullException
    {
        /// <summary>
        /// Конструктор с информационным сообщением и значением параметра
        /// </summary>
        /// <param name="message">Информационное сообщение</param>
        /// <param name="value">значение параметра вызвашвего исключение</param>
        public MessageTypeUserNameNullOrEmptyException(string? message, string? value)
            : base(value, message)
        {
        }
    }
}