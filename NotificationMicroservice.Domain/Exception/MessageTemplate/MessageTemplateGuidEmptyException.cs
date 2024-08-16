namespace NotificationMicroservice.Domain.Exception.MessageTemplate
{
    /// <summary>
    /// Исключение пустого значения идентификатора
    /// </summary>
    public class MessageTemplateGuidEmptyException : ArgumentException
    {
        /// <summary>
        /// Конструктор с информационным сообщением и значением параметра
        /// </summary>
        /// <param name="message">Информационное сообщение</param>
        /// <param name="value">значение параметра вызвашвего исключение</param>
        public MessageTemplateGuidEmptyException(string? message, string? value) 
            : base(message, value)
        {
        }
    }
}