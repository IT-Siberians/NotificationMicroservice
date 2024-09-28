using FluentValidation;
using NotificationMicroservice.Contracts.Rabbit.Events;
using NotificationMicroservice.Validator.Base;

namespace NotificationMicroservice.Validator.Event
{
    public class CreateUserValidator : AbstractValidator<CreateUserEvent>
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
