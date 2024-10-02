using FluentValidation;
using NotificationMicroservice.DataAccess.Models;
using NotificationMicroservice.DataAccess.ValueObject;

namespace NotificationMicroservice.Validator.Base
{
    public class QueueNameValidator : AbstractValidator<string>
    {
        public QueueNameValidator()
        {
            RuleFor(request => request)
                .NotNull()
                .NotEmpty()
                .Matches(QueueName.QUEUE_NAME)
                .Length(BusQueue.MIN_QUEUENAME_LENGTH, BusQueue.MAX_QUEUENAME_LENGTH);
        }
    }
}
