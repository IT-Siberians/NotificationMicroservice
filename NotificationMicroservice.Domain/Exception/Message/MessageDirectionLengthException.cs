namespace NotificationMicroservice.Domain.Exception.Message
{
    /// <summary>
    /// Конструктор с информационным сообщением и значением параметра
    /// </summary>
    /// <param name="message">Информационное сообщение</param>
    /// <param name="length">Значение максимальной длинны</param>
    /// <param name="value">Значение параметра вызвашвего исключение</param>
    internal class MessageDirectionLengthException(string message, int length, string value) : ArgumentOutOfRangeException(value, string.Format(message, length));
}