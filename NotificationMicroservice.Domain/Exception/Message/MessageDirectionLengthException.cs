namespace NotificationMicroservice.Domain.Exception.Message
{
    /// <summary>
    /// Исключение ограничения длинны направления отправки
    /// </summary>
    public class MessageDirectionLengthException : ArgumentException
    {
        /// <summary>
        /// Конструктор с информационным сообщением и значением параметра
        /// </summary>
        /// <param name="message">Информационное сообщение</param>
        /// <param name="value">значение параметра вызвашвего исключение</param>
        public MessageDirectionLengthException(string? message, string? value)
            : base(message, value)
        {
        }
    }
}