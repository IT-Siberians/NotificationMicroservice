using NotificationMicroservice.Domain.Helpers;

namespace NotificationMicroservice.Domain.Exception.ValueObject.Username
{
    /// <summary>
    /// Исключительная ситуация создание пустого Имени пользователя
    /// </summary>
    /// <param name="paramName">Название параметра, в котором произошло исключение</param>
    internal class UsernameEmptyException(string paramName) : ArgumentNullException(paramName, ExceptionMessages.USERNAME_EMPTY_STRING_ERROR);
}
