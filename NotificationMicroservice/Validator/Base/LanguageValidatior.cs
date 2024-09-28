using FluentValidation;
using NotificationMicroservice.Domain.Entities;
using NotificationMicroservice.Domain.Enums;

namespace NotificationMicroservice.Validator.Base
{
    public class LanguageValidatior : AbstractValidator<string>
    {
        public LanguageValidatior()
        {
            RuleFor(request => request)
                .Length(MessageTemplate.LANGUAGE_LENGTH)
                .NotEmpty()
                .NotNull()
                .Must(BeAValidLanguage);
        }

        private bool BeAValidLanguage(string request)
        {
            return Enum.GetNames(typeof(Language))
                .Any(x => x.Equals(request, StringComparison.Ordinal));
        }
    }
}
