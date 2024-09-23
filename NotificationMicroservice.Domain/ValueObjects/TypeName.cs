using NotificationMicroservice.Domain.Entities;
using NotificationMicroservice.Domain.Exception.MessageType;
using NotificationMicroservice.Domain.Helpers;

namespace NotificationMicroservice.Domain.ValueObjects
{
    /// <summary>
    /// Представляет собой значение объекта для имени типа (TypeName).
    /// </summary>
    public class TypeName
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="TypeName"/>.
        /// </summary>
        /// <param name="value">Строковое значение имени типа.</param>
        /// <exception cref="MessageTypeNameNullOrEmptyException">Возникает, когда значение имени типа является null или пустой строкой.</exception>
        /// <exception cref="MessageTypeNameLengthException">Возникает, когда длина имени типа не соответствует заданным ограничениям на минимальную и максимальную длину.</exception>
        public TypeName(string value)
        {
            IsValid(value);

            Value = value;
        }

        /// <summary>
        /// Значение названия типа.
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// Валидация входных данных. Проверяет, что имя типа не является null или пустой строкой и соответствует заданным ограничениям на длину.
        /// </summary>
        /// <param name="name">Название типа сообщения для проверки.</param>
        /// <exception cref="MessageTypeNameNullOrEmptyException">Возникает, когда значение имени типа является null или пустой строкой.</exception>
        /// <exception cref="MessageTypeNameLengthException">Возникает, когда длина имени типа не соответствует заданным ограничениям на минимальную и максимальную длину.</exception>
        private static void IsValid(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new MessageTypeNameNullOrEmptyException(ExceptionMessages.ERROR_TYPE_NAME, name);
            }

            if (name.Length < MessageType.MIN_NAME_LENGTH || name.Length > MessageType.MAX_NAME_LENGTH)
            {
                throw new MessageTypeNameLengthException(ExceptionMessages.ERROR_TYPE_NAME_LENGTH, MessageType.MIN_NAME_LENGTH, MessageType.MAX_NAME_LENGTH, name.Length.ToString());
            }
        }

        /// <summary>
        /// Возвращает строковое представление значения названия типа.
        /// </summary>
        /// <returns>Строковое представление значения названия типа.</returns>
        public override string ToString() => Value;

        /// <summary>
        /// Определяет, равны ли два объекта <see cref="TypeName"/>.
        /// </summary>
        /// <param name="obj">Объект для сравнения.</param>
        /// <returns>TRUE, если объекты равны; иначе FALSE.</returns>
        public override bool Equals(object obj)
        {
            return obj is TypeName other
                && StringComparer.Ordinal.Equals(Value, other.Value);
        }

        /// <summary>
        /// Оператор для проверки равенства двух объектов <see cref="TypeName"/>.
        /// </summary>
        /// <param name="left">Первый объект для сравнения.</param>
        /// <param name="right">Второй объект для сравнения.</param>
        /// <returns>TRUE, если объекты равны; иначе FALSE.</returns>
        public static bool operator ==(TypeName left, TypeName right)
        {
            if (ReferenceEquals(left, null))
                return ReferenceEquals(right, null);
            return left.Equals(right);
        }

        /// <summary>
        /// Оператор для проверки неравенства двух объектов <see cref="TypeName"/>.
        /// </summary>
        /// <param name="left">Первый объект для сравнения.</param>
        /// <param name="right">Второй объект для сравнения.</param>
        /// <returns>TRUE, если объекты не равны; иначе FALSE.</returns>
        public static bool operator !=(TypeName left, TypeName right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Возвращает хеш-код значения названия типа.
        /// </summary>
        /// <returns>Хеш-код значения названия типа.</returns>
        public override int GetHashCode() => StringComparer.Ordinal.GetHashCode(Value);
    }
}
