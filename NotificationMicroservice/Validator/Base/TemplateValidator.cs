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
                .Length(MessageTemplate.TEMPLATE_MIN_LENGTH, MessageTemplate.TEMPLATE_MAX_LENGTH);
        }
    }
}
