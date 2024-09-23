using NotificationMicroservice.Domain.Entities;
using NotificationMicroservice.Domain.Exception.ValueObject.Name;

namespace NotificationMicroservice.Domain.ValueObjects
{
    /// <summary>
    /// Представляет собой значение объекта для ФИО пользователя (FullName).
    /// </summary>
    public class FullName
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="FullName"/>.
        /// </summary>
        /// <param name="value">Строковое значение ФИО пользователя.</param>
        /// <exception cref="NameEmptyException">Возникает, когда значение ФИО пользователя является null, пустой строкой или состоит только из пробелов.</exception>
        /// <exception cref="NameLengthException">Возникает, когда длина значения ФИО пользователя не соответствует заданным ограничениям на минимальную и максимальную длину.</exception>
        public FullName(string value)
        {
            IsValid(value);

            Value = value;
        }

        /// <summary>
        /// Значение ФИО пользователя.
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// Возвращает строковое представление значения ФИО пользователя.
        /// </summary>
        /// <returns>Строковое представление значения ФИО пользователя.</returns>
        public override string ToString() => Value;

        /// <summary>
        /// Проверяет, является ли значение ФИО пользователя валидным.
        /// </summary>
        /// <param name="value">Значение ФИО пользователя для проверки.</param>
        /// <exception cref="NameEmptyException">Возникает, когда значение ФИО пользователя является null, пустой строкой или состоит только из пробелов.</exception>
        /// <exception cref="NameLengthException">Возникает, когда длина значения ФИО пользователя не соответствует заданным ограничениям на минимальную и максимальную длину.</exception>
        private void IsValid(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new NameEmptyException(nameof(value));
            }

            if (value.Length < User.MIN_FULLNAME_LENGTH || value.Length > User.MAX_FULLNAME_LENGTH)
            {
                throw new NameLengthException(value.Length, User.MIN_FULLNAME_LENGTH, User.MAX_FULLNAME_LENGTH, nameof(value));
            }
        }

        /// <summary>
        /// Определяет, равны ли два объекта <see cref="FullName"/>.
        /// </summary>
        /// <param name="obj">Объект для сравнения.</param>
        /// <returns>TRUE, если объекты равны; иначе FALSE.</returns>
        public override bool Equals(object obj)
        {
            return obj is FullName other
                && StringComparer.Ordinal.Equals(Value, other.Value);
        }

        /// <summary>
        /// Оператор для проверки равенства двух объектов <see cref="FullName"/>.
        /// </summary>
        /// <param name="left">Первый объект для сравнения.</param>
        /// <param name="right">Второй объект для сравнения.</param>
        /// <returns>TRUE, если объекты равны; иначе FALSE.</returns>
        public static bool operator ==(FullName left, FullName right)
        {
            return Equals(left, right);
        }

        /// <summary>
        /// Оператор для проверки неравенства двух объектов <see cref="FullName"/>.
        /// </summary>
        /// <param name="left">Первый объект для сравнения.</param>
        /// <param name="right">Второй объект для сравнения.</param>
        /// <returns>TRUE, если объекты не равны; иначе FALSE.</returns>
        public static bool operator !=(FullName left, FullName right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Возвращает хеш-код значения ФИО пользователя.
        /// </summary>
        /// <returns>Хеш-код значения ФИО пользователя.</returns>
        public override int GetHashCode() => StringComparer.Ordinal.GetHashCode(Value);
    }
}
