using FluentValidation;

namespace NotificationMicroservice.Validator.Base
{
    public class TemplateValidator : AbstractValidator<string>
    {
        public TemplateValidator() 
        {
            RuleFor(request => request)
                .MinimumLength(20)
                .NotEmpty()
                .NotNull();
        }
    }
}
