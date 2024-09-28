using FluentValidation;
using NotificationMicroservice.Contracts.BusQueue;
using NotificationMicroservice.Validator.Base;

namespace NotificationMicroservice.Validator.Queue
{
    public class DeleteBusQueueValidator : AbstractValidator<DeleteBusQueueRequest>
    {
        public DeleteBusQueueValidator()
        {
            RuleFor(type => type.ModifiedByUserId)
                    .SetValidator(new GuidValidator());
        }
    }
}
