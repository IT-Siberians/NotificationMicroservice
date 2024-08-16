namespace NotificationMicroservice.Domain.Exception.MessageTemplate
{
    /// <summary>
    /// Исключение ограничения длинны кодировки языка
    /// </summary>
    public class MessageTemplateLanguageNullOrEmptyException : ArgumentNullException
    {
        /// <summary>
        /// Конструктор с информационным сообщением и значением параметра
        /// </summary>
        /// <param name="message">Информационное сообщение</param>
        public MessageTemplateLanguageNullOrEmptyException(string? message)
            : base(message)
        {
        }
    }
}