using NotificationMicroservice.Domain.Helpers;

namespace NotificationMicroservice.Domain.Exception.ValueObject.QueueName
{
    public class QueueNameLengthException(int valueLength, int lengthMin, int lengthMax, string paramName) : ArgumentOutOfRangeException(paramName, string.Format(ExceptionMessages.ERROR_QUEUENAME_LENGTH, paramName, lengthMin, lengthMax, valueLength));
}
