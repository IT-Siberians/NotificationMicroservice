using FluentValidation;
using NotificationMicroservice.Contracts.Rabbit.Events;
using NotificationMicroservice.Validator.Base;

namespace NotificationMicroservice.Validator.Event
{
    public class ConfirmationEmailValidator : AbstractValidator<ConfirmationEmailEvent>
    {
        public ConfirmationEmailValidator()
        {
            RuleFor(request => request.Email)
                .SetValidator(new EmailValidator());
            RuleFor(request => request.Username)
                .SetValidator(new FullNameValidator());
            RuleFor(request => request.Link)
                .SetValidator(new UriValidator());
        }
    }
}
