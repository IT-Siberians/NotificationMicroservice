namespace NotificationMicroservice.Domain.Exception.MessageType
{
    /// <summary>
    /// Конструктор с информационным сообщением и значением параметра
    /// </summary>
    /// <param name="message">Информационное сообщение</param>
    /// <param name="lengthMin">Значение минимальной длинны</param>
    /// <param name="lengthMax">Значение максимальной длинны</param>
    /// <param name="value">Значение параметра вызвашвего исключение</param>
    internal class MessageTypeNameLengthException(string message, int lengthMin, int lengthMax, string value) : ArgumentOutOfRangeException(value, string.Format(message, lengthMin, lengthMax));
}