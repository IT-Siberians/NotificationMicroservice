using NotificationMicroservice.Domain.Helpers;

namespace NotificationMicroservice.Domain.Exception.ValueObject.QueueName
{
    /// <summary>
    /// Конструктор с информационным сообщением и значением параметра
    /// </summary>
    /// <param name="value">Значение параметра вызвашвего исключение</param>
    public class QueueNameInvalidException(string value) : FormatException(string.Format(ExceptionMessages.ERROR_QUEUENAME, value));
}
