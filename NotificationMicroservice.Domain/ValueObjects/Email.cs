using NotificationMicroservice.Domain.Exception.ValueObject.Email;
using NotificationMicroservice.Domain.Helpers;
using NotificationMicroservice.Domain.ValueObjects.Abstraction;
using System.Text.RegularExpressions;

namespace NotificationMicroservice.Domain.ValueObjects
{
    /// <summary>
    /// Представляет значение Email и обеспечивает проверку его корректности.
    /// </summary>
    /// <param name="value">Строка, представляющая Email-адрес.</param>
    /// <exception cref="EmailInvalidException">Выбрасывается, если переданная строка не соответствует формату Email.</exception>
    public class Email(string value) : StringValueObject(value)
    {
        // Регулярное выражение для проверки корректности Email-адреса
        private static readonly Regex ValidationRegex = new Regex(
            RegexValues.EMAIL,
            RegexOptions.Singleline | RegexOptions.Compiled);

        /// <summary>
        /// Проверяет, соответствует ли переданная строка формату корректного Email-адреса.
        /// </summary>
        /// <param name="value">Строка для проверки.</param>
        /// <returns><c>true</c>, если строка соответствует формату Email; в противном случае <c>false</c>.</returns>
        protected override void IsValid(string value)
        {
            if (!(!string.IsNullOrWhiteSpace(value) && ValidationRegex.IsMatch(value)))
            {
                throw new EmailInvalidException(value);
            }
        }
    }
}