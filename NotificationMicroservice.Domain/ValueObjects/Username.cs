using NotificationMicroservice.Domain.Entities;
using NotificationMicroservice.Domain.Exception.ValueObject.Username;

namespace NotificationMicroservice.Domain.ValueObjects
{
    /// <summary>
    /// Представляет собой значение объекта для имени пользователя (username).
    /// </summary>
    public class Username
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Username"/> с заданным значением.
        /// </summary>
        /// <param name="value">Значение имени пользователя.</param>
        /// <exception cref="UsernameEmptyException">Если значение имени пользователя пустое или состоит только из пробелов.</exception>
        /// <exception cref="UsernameLengthException">Если длина значения имени пользователя выходит за пределы допустимого диапазона.</exception>
        public Username(string value)
        {
            IsValid(value);

            Value = value;
        }

        /// <summary>
        /// Значение имени пользователя.
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// Проверяет, является ли значение имени пользователя валидным.
        /// </summary>
        /// <param name="value">Значение имени пользователя для проверки.</param>
        /// <exception cref="UsernameEmptyException">Если значение имени пользователя пустое или состоит только из пробелов.</exception>
        /// <exception cref="UsernameLengthException">Если длина значения имени пользователя выходит за пределы допустимого диапазона.</exception>
        private void IsValid(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new UsernameEmptyException(nameof(value));
            }

            if (value.Length < User.MIN_USERNAME_LENGTH || value.Length > User.MAX_USERNAME_LENGTH)
            {
                throw new UsernameLengthException(value.Length, User.MIN_USERNAME_LENGTH, User.MAX_USERNAME_LENGTH, nameof(value));
            }
        }

        /// <summary>
        /// Возвращает строковое представление значения имени пользователя.
        /// </summary>
        /// <returns>Строковое представление значения имени пользователя.</returns>
        public override string ToString() => Value;

        /// <summary>
        /// Определяет, равны ли два объекта <see cref="Username"/>.
        /// </summary>
        /// <param name="obj">Объект для сравнения.</param>
        /// <returns>TRUE, если объекты равны; иначе FALSE.</returns>
        public override bool Equals(object obj)
        {
            return obj is Username other
                && StringComparer.Ordinal.Equals(Value, other.Value);
        }

        /// <summary>
        /// Оператор для проверки равенства двух объектов <see cref="Username"/>.
        /// </summary>
        /// <param name="left">Первый объект для сравнения.</param>
        /// <param name="right">Второй объект для сравнения.</param>
        /// <returns>TRUE, если объекты равны; иначе FALSE.</returns>
        public static bool operator ==(Username left, Username right)
        {
            if (ReferenceEquals(left, null))
                return ReferenceEquals(right, null);
            return left.Equals(right);
        }

        /// <summary>
        /// Оператор для проверки неравенства двух объектов <see cref="Username"/>.
        /// </summary>
        /// <param name="left">Первый объект для сравнения.</param>
        /// <param name="right">Второй объект для сравнения.</param>
        /// <returns>TRUE, если объекты не равны; иначе FALSE.</returns>
        public static bool operator !=(Username left, Username right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Возвращает хеш-код значения имени пользователя.
        /// </summary>
        /// <returns>Хеш-код значения имени пользователя.</returns>
        public override int GetHashCode() => StringComparer.Ordinal.GetHashCode(Value);
    }
}