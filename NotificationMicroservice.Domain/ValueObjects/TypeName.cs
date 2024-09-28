using NotificationMicroservice.Domain.Entities;
using NotificationMicroservice.Domain.Exception.MessageType;
using NotificationMicroservice.Domain.Helpers;
using NotificationMicroservice.Domain.ValueObjects.Abstraction;

namespace NotificationMicroservice.Domain.ValueObjects
{
    /// <summary>
    /// Представляет собой значение объекта для имени типа (TypeName).
    /// </summary>
    /// <param name="value">Строковое значение имени типа.</param>
    /// <exception cref="MessageTypeNameNullOrEmptyException">Возникает, когда значение имени типа является null или пустой строкой.</exception>
    /// <exception cref="MessageTypeNameLengthException">Возникает, когда длина имени типа не соответствует заданным ограничениям на минимальную и максимальную длину.</exception>
    public class TypeName(string value) : StringValueObject(value)
    {
        /// <summary>
        /// Валидация входных данных. Проверяет, что имя типа не является null или пустой строкой и соответствует заданным ограничениям на длину.
        /// </summary>
        /// <param name="name">Название типа сообщения для проверки.</param>
        /// <exception cref="MessageTypeNameNullOrEmptyException">Возникает, когда значение имени типа является null или пустой строкой.</exception>
        /// <exception cref="MessageTypeNameLengthException">Возникает, когда длина имени типа не соответствует заданным ограничениям на минимальную и максимальную длину.</exception>
        protected override void IsValid(string name)
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
    }
}
