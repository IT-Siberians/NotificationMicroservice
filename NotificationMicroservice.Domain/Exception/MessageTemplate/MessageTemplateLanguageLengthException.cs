namespace NotificationMicroservice.Domain.Exception.MessageTemplate
{
    /// <summary>
    /// Исключение ограничения длинны кодировки языка
    /// </summary>
    public class MessageTemplateLanguageLengthException : ArgumentException
    {
        /// <summary>
        /// Конструктор с информационным сообщением и значением параметра
        /// </summary>
        /// <param name="message">Информационное сообщение</param>
        /// <param name="value">значение параметра вызвашвего исключение</param>
        public MessageTemplateLanguageLengthException(string? message, string? value) 
            : base(message, value)
        {
        }
    }
}