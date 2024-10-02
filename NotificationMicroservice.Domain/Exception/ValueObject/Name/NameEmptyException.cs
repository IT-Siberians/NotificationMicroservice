using NotificationMicroservice.Domain.Helpers;

namespace NotificationMicroservice.Domain.Exception.ValueObject.Name
{
    /// <summary>
    /// Исключительная ситуация создание пустого Имени пользователя
    /// </summary>
    /// <param name="paramName">Название параметра, в котором произошло исключение</param>
    internal class NameEmptyException(string paramName) : ArgumentNullException(paramName, ExceptionMessages.ERROR_NAME_EMPTY_STRING);
}
