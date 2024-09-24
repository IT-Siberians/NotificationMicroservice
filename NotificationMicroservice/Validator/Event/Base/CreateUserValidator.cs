using FluentValidation;
using NotificationMicroservice.Contracts.Events.Base;
using NotificationMicroservice.Validator.Base;

namespace NotificationMicroservice.Validator.Event.Base
{
    public class CreateUserValidator : AbstractValidator<CreateUser>
    {
        public CreateUserValidator()
        {
            RuleFor(user => user.Id)
                .SetValidator(new GuidValidator());
            RuleFor(user => user.Email)
                .SetValidator(new EmailValidator());
            RuleFor(user => user.Username)
                .SetValidator(new FullNameValidator());
            RuleFor(user => user.FullName)
                .SetValidator(new FullNameValidator());
        }
    }
}
