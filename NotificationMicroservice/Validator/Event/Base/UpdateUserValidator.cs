using FluentValidation;
using NotificationMicroservice.Contracts.Events.Base;
using NotificationMicroservice.Validator.Base;

namespace NotificationMicroservice.Validator.Event.Base
{
    public class UpdateUserValidator : AbstractValidator<UpdateUser>
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
