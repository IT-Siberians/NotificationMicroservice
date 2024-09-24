using FluentValidation;
using NotificationMicroservice.Contracts.Events;
using NotificationMicroservice.Validator.Event.Base;

namespace NotificationMicroservice.Validator.Event
{
    public class CreateUserEventValidator : AbstractValidator<CreateUserEvent>
    {
        public CreateUserEventValidator()
        {
            RuleFor(request => request.Id)
                .IsInEnum();
            RuleFor(request => request.Data)
                .SetValidator(new CreateUserValidator());
        }
    }
}
