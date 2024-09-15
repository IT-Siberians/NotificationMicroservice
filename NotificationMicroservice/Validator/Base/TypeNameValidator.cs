using FluentValidation;
using NotificationMicroservice.Domain.Entities;

namespace NotificationMicroservice.Validator.Base
{
    public class TypeNameValidator : AbstractValidator<string>
    {
        public TypeNameValidator()
        {
            RuleFor(request => request)
                .NotNull()
                .NotEmpty()
                .Length(MessageType.MIN_NAME_LENGTH, MessageType.MAX_NAME_LENGTH);
        }

    }
}
