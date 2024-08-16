namespace NotificationMicroservice.Domain.Exception.MessageTemplate
{
    /// <summary>
    /// Исключение пустого значения пользоватля
    /// </summary>
    public class MessageTemplateUserNameNullOrEmptyException : ArgumentNullException
    {
        /// <summary>
        /// Конструктор с информационным сообщением и значением параметра
        /// </summary>
        /// <param name="message">Информационное сообщение</param>
        /// <param name="value">значение параметра вызвашвего исключение</param>
        public MessageTemplateUserNameNullOrEmptyException(string? message, string? value)
            : base(value, message)
        {
        }
    }
}