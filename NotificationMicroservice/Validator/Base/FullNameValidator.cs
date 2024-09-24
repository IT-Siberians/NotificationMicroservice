using FluentValidation;
using NotificationMicroservice.Domain.Entities;

namespace NotificationMicroservice.Validator.Base
{
    public class FullNameValidator : AbstractValidator<string>
    {
        public FullNameValidator()
        {
            RuleFor(request => request)
                .NotEmpty()
                .NotNull()
                .Length(User.MIN_FULLNAME_LENGTH, User.MAX_FULLNAME_LENGTH);
        }
    }
}
