using NotificationMicroservice.Domain.Helpers;

namespace NotificationMicroservice.Domain.Exception.ValueObject.Name
{
    /// <summary>
    /// Исключительная ситуация создание Имени пользователя длиннее допустимого
    /// </summary>
    /// <param name="valueLength">Длина Имени пользователя</param>
    /// <param name="lengthMin">Значение минимальной длинны</param>
    /// <param name="lengthMax">Значение максимальной длинны</param>
    /// <param name="paramName">Название параметра, в котором произошло исключение</param>
    internal class NameLengthException(int valueLength, int lengthMin, int lengthMax, string paramName) : ArgumentOutOfRangeException(paramName, string.Format(ExceptionMessages.NAME_LENGTH_ERROR, paramName, lengthMin, lengthMax, valueLength));
}
