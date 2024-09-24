using FluentValidation;
using NotificationMicroservice.Contracts.Events;
using NotificationMicroservice.Validator.Event.Base;

namespace NotificationMicroservice.Validator.Event
{
    public class UpdateUserEventValidator : AbstractValidator<UpdateUserEvent>
    {
        public UpdateUserEventValidator()
        {
            RuleFor(request => request.Id)
                .IsInEnum();
            RuleFor(request => request.Data)
                .SetValidator(new UpdateUserValidator());
        }
    }
}
