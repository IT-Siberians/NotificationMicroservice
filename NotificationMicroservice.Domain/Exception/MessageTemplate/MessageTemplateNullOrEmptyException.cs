namespace NotificationMicroservice.Domain.Exception.MessageTemplate
{
    /// <summary>
    /// Конструктор с информационным сообщением и значением параметра
    /// </summary>
    /// <param name="message">Информационное сообщение</param>
    /// <param name="value">Значение параметра вызвашвего исключение</param>
    public class MessageTemplateNullOrEmptyException(string message, string value) : ArgumentNullException(value, message);
}