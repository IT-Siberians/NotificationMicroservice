using FluentValidation;
using NotificationMicroservice.Contracts.BusQueue;
using NotificationMicroservice.Validator.Base;

namespace NotificationMicroservice.Validator.Queue
{
    public class AddBusQueueValidator : AbstractValidator<AddBusQueueRequest>
    {
        public AddBusQueueValidator()
        {

            RuleFor(type => type.QueueName)
                .SetValidator(new QueueNameValidator());

            RuleFor(type => type.MessageTypeId)
                .SetValidator(new GuidValidator());

            RuleFor(type => type.CreatedByUserId)
                    .SetValidator(new GuidValidator());
        }
    }
}
