using FluentValidation;
using NotificationMicroservice.Domain.Entities;

namespace NotificationMicroservice.Validator.Base
{
    public class TemplateValidator : AbstractValidator<string>
    {
        public TemplateValidator()
        {
            RuleFor(request => request)
                .NotEmpty()
                .NotNull()
                .MinimumLength(MessageTemplate.TEMPLATE_MIN_LENGTH);
        }
    }
}
