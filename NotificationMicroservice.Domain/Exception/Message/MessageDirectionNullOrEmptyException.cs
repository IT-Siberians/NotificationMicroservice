namespace NotificationMicroservice.Domain.Exception.Message
{
    /// <summary>
    /// Исключение пустого значения направления отправки
    /// </summary>
    public class MessageDirectionNullOrEmptyException : ArgumentNullException
    {
        /// <summary>
        /// Конструктор с информационным сообщением и значением параметра
        /// </summary>
        /// <param name="message">Информационное сообщение</param>
        /// <param name="value">значение параметра вызвашвего исключение</param>
        public MessageDirectionNullOrEmptyException(string? message, string? value)
            : base(value, message)
        {
        }
    }
}