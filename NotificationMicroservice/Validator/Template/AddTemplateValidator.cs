using FluentValidation;
using NotificationMicroservice.Contracts.Template;
using NotificationMicroservice.Validator.Base;

namespace NotificationMicroservice.Validator.Template
{
    public class AddTemplateValidator : AbstractValidator<AddTemplateRequest>
    {
        public AddTemplateValidator()
        {

            RuleFor(template => template.MessageTypeId)
                .NotEmpty();

            RuleFor(template => template.Language)
                .SetValidator(new LanguageValidatior());

            RuleFor(template => template.Template)
                .SetValidator(new TemplateValidator());

            RuleFor(template => template.CreatedUserId)
                .SetValidator(new GuidValidator());
        }
    }
}
