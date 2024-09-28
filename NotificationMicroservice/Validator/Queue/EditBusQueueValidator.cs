using FluentValidation;
using NotificationMicroservice.Contracts.BusQueue;
using NotificationMicroservice.Validator.Base;

namespace NotificationMicroservice.Validator.Queue
{
    public class EditBusQueueValidator : AbstractValidator<EditBusQueueRequest>
    {
        public EditBusQueueValidator()
        {
            RuleFor(type => type.MessageTypeId)
                    .SetValidator(new GuidValidator());

            RuleFor(type => type.ModifiedByUserId)
                    .SetValidator(new GuidValidator());
        }
    }
}
