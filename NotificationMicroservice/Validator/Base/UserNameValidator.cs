using FluentValidation;

namespace NotificationMicroservice.Validator.Base
{
    public class UserNameValidator : AbstractValidator<string>
    {
        public UserNameValidator()
        {

            RuleFor(request => request)
                .NotNull()
                .NotEmpty();
        }
    }
}
