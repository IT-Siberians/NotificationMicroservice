using NotificationMicroservice.Domain.Exception.Message;
using NotificationMicroservice.Domain.Helpers;
using NotificationMicroservice.Domain.ValueObjects.Abstraction;

namespace NotificationMicroservice.Domain.ValueObjects
{
    /// <summary>
    /// Представляет текст сообщения и обеспечивает проверку его корректности.
    /// </summary>
    public class MessageText : StringValueObject
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="MessageText"/>.
        /// </summary>
        /// <param name="value">Строка, представляющая текст сообщения.</param>
        public MessageText(string value) : base(value)
        {
        }

        /// <summary>
        /// Проверяет, является ли значение текста сообщения валидным.
        /// </summary>
        /// <param name="value">Значение текста сообщения.</param>
        /// <exception cref="MessageTextNullOrEmptyException">Выбрасывается, если значение текста сообщения пустое или null.</exception>
        protected override void IsValid(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new MessageTextNullOrEmptyException(ExceptionMessages.ERROR_TEXT, value);
            }
        }
    }
}
