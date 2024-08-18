namespace NotificationMicroservice.Domain.Exception.MessageTemplate
{
    /// <summary>
    /// Конструктор с информационным сообщением и значением параметра
    /// </summary>
    /// <param name="message">Информационное сообщение</param>
    /// <param name="value">значение параметра вызвашвего исключение</param>
    public class MessageTemplateLanguageLengthException(string message, string value) : ArgumentException(message, value)
    {

    }
}