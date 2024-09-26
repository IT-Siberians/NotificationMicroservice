namespace NotificationMicroservice.Domain.Exception.MessageTemplate
{
    /// <summary>
    /// Конструктор с информационным сообщением и значением параметра
    /// </summary>
    /// <param name="message">Информационное сообщение</param>
    /// <param name="value">Значение параметра вызвашвего исключение</param>
    internal class MessageTemplateLanguageNullOrEmptyException(string message, string value) : ArgumentNullException(value, message);
}