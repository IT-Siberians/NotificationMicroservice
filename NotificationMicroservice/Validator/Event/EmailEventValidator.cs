using FluentValidation;
using NotificationMicroservice.Contracts.Events;
using NotificationMicroservice.Validator.Event.Base;

namespace NotificationMicroservice.Validator.Event
{
    public class EmailEventValidator : AbstractValidator<ConfirmationEmailEvent>
    {
        public EmailEventValidator()
        {
            RuleFor(request => request.Id)
                .IsInEnum();
            RuleFor(request => request.Data)
                .SetValidator(new ConfirmationEmailValidator());
        }
    }
}
