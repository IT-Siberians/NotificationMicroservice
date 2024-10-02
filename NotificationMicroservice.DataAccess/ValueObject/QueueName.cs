using NotificationMicroservice.DataAccess.Models;
using NotificationMicroservice.Domain.ValueObjects.Abstraction;
using System.Text.RegularExpressions;

namespace NotificationMicroservice.DataAccess.ValueObject
{
    public class QueueName(string value) : StringValueObject(value)
    {
        public const string QUEUE_NAME = @"^[A-Za-z0-9]+$";
        // Регулярное выражение для проверки корректности Email-адреса
        private static readonly Regex ValidationRegex = new Regex(QUEUE_NAME, RegexOptions.Singleline | RegexOptions.Compiled);

        protected override void IsValid(string value)
        {
            if (!(!string.IsNullOrWhiteSpace(value) && ValidationRegex.IsMatch(value)))
            {
                throw new FormatException(string.Format("QueueName is not valid. Value is '{0}'.", value));
            }

            if (value.Length < BusQueue.MIN_QUEUENAME_LENGTH || value.Length > BusQueue.MAX_QUEUENAME_LENGTH)
            {
                throw new ArgumentOutOfRangeException(
                    value,
                    string.Format(
                        "The {0} of the queue name is invalid. It should be between '{1}' and '{2}' characters long. Current value '{3}.'",
                        nameof(value),
                        BusQueue.MIN_QUEUENAME_LENGTH,
                        BusQueue.MAX_QUEUENAME_LENGTH,
                        value.Length));
            }
        }
    }
}
