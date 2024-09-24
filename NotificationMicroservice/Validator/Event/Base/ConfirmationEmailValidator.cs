using FluentValidation;
using NotificationMicroservice.Contracts.Events.Base;
using NotificationMicroservice.Validator.Base;

namespace NotificationMicroservice.Validator.Event.Base
{
    public class ConfirmationEmailValidator : AbstractValidator<ConfirmationEmail>
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
