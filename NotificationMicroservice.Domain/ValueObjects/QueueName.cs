using NotificationMicroservice.Domain.Exception.MessageTemplate;
using NotificationMicroservice.Domain.Helpers;
using NotificationMicroservice.Domain.ValueObjects.Abstraction;

namespace NotificationMicroservice.Domain.ValueObjects
{
    public class QueueName(string value) : StringValueObject(value)
    {
        protected override void IsValid(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new MessageTemplateNullOrEmptyException(ExceptionMessages.ERROR_TEMPLATE, value);
            }
        }
    }
}
