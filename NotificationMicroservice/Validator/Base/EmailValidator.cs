using FluentValidation;

namespace NotificationMicroservice.Validator.Base
{
    public class EmailValidator : AbstractValidator<string>
    {
        public EmailValidator()
        {
            RuleFor(request => request)
                .NotNull()
                .NotEmpty()
                .EmailAddress();
        }
    }
}
