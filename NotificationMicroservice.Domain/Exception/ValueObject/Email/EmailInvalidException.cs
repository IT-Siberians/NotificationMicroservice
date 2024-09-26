using NotificationMicroservice.Domain.Helpers;

namespace NotificationMicroservice.Domain.Exception.ValueObject.Email
{
    /// <summary>
    /// Конструктор с информационным сообщением и значением параметра
    /// </summary>
    /// <param name="value">Информационное сообщение</param>
    internal class EmailInvalidException(string value) : FormatException(string.Format(ExceptionMessages.ERROR_EMAIL, value));
}