using FluentValidation;
using NotificationMicroservice.Domain.Entities;

namespace NotificationMicroservice.Validator.Base
{
    public class LanguageValidatior : AbstractValidator<string>
    {
        public LanguageValidatior()
        {
            RuleFor(request => request)
                .Length(MessageTemplate.LANGUAGE_LENGTH)
                .NotEmpty()
                .NotNull();
        }
    }
}
