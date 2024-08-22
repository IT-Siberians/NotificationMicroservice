using FluentValidation;

namespace NotificationMicroservice.Validator.Base
{
    public class LanguageValidatior : AbstractValidator<string>
    {
        public LanguageValidatior() 
        {
            RuleFor(request => request)
                .Length(3)
                .NotEmpty()
                .NotNull();
        }
    }
}
