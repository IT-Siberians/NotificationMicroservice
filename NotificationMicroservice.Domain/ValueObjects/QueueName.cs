using NotificationMicroservice.Domain.Entities;
using NotificationMicroservice.Domain.Exception.ValueObject.QueueName;
using NotificationMicroservice.Domain.Helpers;
using NotificationMicroservice.Domain.ValueObjects.Abstraction;
using System.Text.RegularExpressions;

namespace NotificationMicroservice.Domain.ValueObjects
{
    public class QueueName(string value) : StringValueObject(value)
    {
        // Регулярное выражение для проверки корректности Email-адреса
        private static readonly Regex ValidationRegex = new Regex(
            RegexValues.QUEUENAME,
            RegexOptions.Singleline | RegexOptions.Compiled);

        protected override void IsValid(string value)
        {
            if (!(!string.IsNullOrWhiteSpace(value) && ValidationRegex.IsMatch(value)))
            {
                throw new QueueNameInvalidException(value);
            }

            if (value.Length < BusQueue.MIN_QUEUENAME_LENGTH || value.Length > BusQueue.MAX_QUEUENAME_LENGTH)
            {
                throw new QueueNameLengthException(value.Length, BusQueue.MIN_QUEUENAME_LENGTH, BusQueue.MAX_QUEUENAME_LENGTH, nameof(value));
            }
        }
    }
}
