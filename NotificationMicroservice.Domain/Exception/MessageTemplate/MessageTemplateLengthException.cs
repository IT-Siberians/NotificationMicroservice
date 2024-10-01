namespace NotificationMicroservice.Domain.Exception.MessageTemplate
{
    /// <summary>
    /// Конструктор с информационным сообщением и значением параметра
    /// </summary>
    /// <param name="message">Информационное сообщение</param>
    /// <param name="lengthMin">Значение минимальной длинны</param>
    /// <param name="value">Значение параметра вызвашвего исключение</param>
    internal class MessageTemplateLengthException(string message, int lengthMin, string value) : ArgumentOutOfRangeException(value, string.Format(message, lengthMin));
}
