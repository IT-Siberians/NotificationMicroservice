using FluentValidation;
using NotificationMicroservice.Domain.Entities;

namespace NotificationMicroservice.Validator.Base
{
    public class UserNameValidator : AbstractValidator<string>
    {
        public UserNameValidator()
        {
            RuleFor(request => request)
                .NotEmpty()
                .NotNull()
                .Length(User.MIN_USERNAME_LENGTH, User.MAX_USERNAME_LENGTH);
        }
    }
}
