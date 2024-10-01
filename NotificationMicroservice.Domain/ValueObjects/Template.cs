using NotificationMicroservice.Domain.Entities;
using NotificationMicroservice.Domain.Exception.MessageTemplate;
using NotificationMicroservice.Domain.Helpers;
using NotificationMicroservice.Domain.ValueObjects.Abstraction;

namespace NotificationMicroservice.Domain.ValueObjects
{
    /// <summary>
    /// Представляет собой шаблон уведомления.
    /// </summary>
    /// <param name="value">Значение шаблона.</param>
    /// <exception cref="MessageTemplateNullOrEmptyException">Если значение шаблона пустое или null.</exception>
    /// <exception cref="MessageTemplateLengthException">Если длина значения шаблона выходит за пределы допустимого диапазона.</exception>
    public class Template(string value) : StringValueObject(value)
    {
        /// <summary>
        /// Проверяет, является ли значение шаблона допустимым.
        /// </summary>
        /// <param name="value">Значение шаблона.</param>
        /// <exception cref="MessageTemplateNullOrEmptyException">Если значение шаблона пустое или null.</exception>
        /// <exception cref="MessageTemplateLengthException">Если длина значения шаблона выходит за пределы допустимого диапазона.</exception>
        protected override void IsValid(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new MessageTemplateNullOrEmptyException(ExceptionMessages.ERROR_TEMPLATE, value);
            }

            if (value.Length < MessageTemplate.TEMPLATE_MIN_LENGTH)
            {
                throw new MessageTemplateLengthException(ExceptionMessages.ERROR_TEMPLATE_LENGTH, MessageTemplate.TEMPLATE_MIN_LENGTH, value.Length.ToString());
            }
        }
    }
}