using NotificationMicroservice.Domain.Entities;
using NotificationMicroservice.Domain.Exception.ValueObject.Name;
using NotificationMicroservice.Domain.ValueObjects.Abstraction;

namespace NotificationMicroservice.Domain.ValueObjects
{
    /// <summary>
    /// Представляет собой значение объекта для имени пользователя (username).
    /// </summary>
    /// <param name="value">Значение имени пользователя.</param>
    /// <exception cref="NameEmptyException">Если значение имени пользователя пустое или состоит только из пробелов.</exception>
    /// <exception cref="NameLengthException">Если длина значения имени пользователя выходит за пределы допустимого диапазона.</exception>
    public class Username(string value) : StringValueObject(value)
    {
        /// <summary>
        /// Проверяет, является ли значение имени пользователя валидным.
        /// </summary>
        /// <param name="value">Значение имени пользователя для проверки.</param>
        /// <exception cref="NameEmptyException">Если значение имени пользователя пустое или состоит только из пробелов.</exception>
        /// <exception cref="NameLengthException">Если длина значения имени пользователя выходит за пределы допустимого диапазона.</exception>
        protected override void IsValid(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new NameEmptyException(nameof(value));
            }

            if (value.Length < User.MIN_USERNAME_LENGTH || value.Length > User.MAX_USERNAME_LENGTH)
            {
                throw new NameLengthException(value.Length, User.MIN_USERNAME_LENGTH, User.MAX_USERNAME_LENGTH, nameof(value));
            }
        }
    }
}