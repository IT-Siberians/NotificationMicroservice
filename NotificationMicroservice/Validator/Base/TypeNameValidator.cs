using FluentValidation;

namespace NotificationMicroservice.Validator.Base
{
    public class TypeNameValidator : AbstractValidator<string>
    {
        public TypeNameValidator()
        {
            RuleFor(request => request)
                .NotNull()
                .NotEmpty()
                .Length(20, 50);
        }

    }
}
