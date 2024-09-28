using FluentValidation;
using NotificationMicroservice.Domain.Entities;

namespace NotificationMicroservice.Validator.Base
{
    public class QueueNameValidator : AbstractValidator<string>
    {
        public QueueNameValidator()
        {
            RuleFor(request => request)
                .NotNull()
                .NotEmpty()
                .Length(BusQueue.MIN_QUEUENAME_LENGTH, BusQueue.MAX_QUEUENAME_LENGTH);
        }
    }
}
