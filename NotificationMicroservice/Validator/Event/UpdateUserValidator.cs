using FluentValidation;
using NotificationMicroservice.Contracts.Rabbit.Events;
using NotificationMicroservice.Validator.Base;

namespace NotificationMicroservice.Validator.Event
{
    public class UpdateUserValidator : AbstractValidator<UpdateUserEvent>
    {
        public UpdateUserValidator()
        {
            RuleFor(user => user.Id)
                    .SetValidator(new GuidValidator());
            RuleFor(user => user.Email)
                .SetValidator(new EmailValidator());
            RuleFor(user => user.FullName)
                .SetValidator(new FullNameValidator());
        }
    }
}
