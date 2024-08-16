namespace NotificationMicroservice.Domain.Exception.Message
{
    /// <summary>
    /// Исключение пустого значения текста отправляемого сообщения
    /// </summary>
    public class MessageTextNullOrEmptyException : ArgumentNullException
    {
        /// <summary>
        /// Конструктор с информационным сообщением и значением параметра
        /// </summary>
        /// <param name="message">Информационное сообщение</param>
        /// <param name="value">значение параметра вызвашвего исключение</param>
        public MessageTextNullOrEmptyException(string? message, string? value) 
            : base(value, message)
        {
        }
    }
}