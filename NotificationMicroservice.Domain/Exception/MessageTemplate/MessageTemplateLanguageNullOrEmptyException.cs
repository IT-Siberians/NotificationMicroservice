namespace NotificationMicroservice.Domain.Exception.MessageTemplate
{
    /// <summary>
    /// Конструктор с информационным сообщением и значением параметра
    /// </summary>
    /// <param name="message">Информационное сообщение</param>
    public class MessageTemplateLanguageNullOrEmptyException(string message) : ArgumentNullException(message)
    {

    }
}