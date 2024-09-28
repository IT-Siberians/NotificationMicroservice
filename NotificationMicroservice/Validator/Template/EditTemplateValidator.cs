using FluentValidation;
using NotificationMicroservice.Contracts.Template;
using NotificationMicroservice.Validator.Base;

namespace NotificationMicroservice.Validator.Template
{
    public class EditTemplateValidator : AbstractValidator<EditTemplateRequest>
    {
        public EditTemplateValidator()
        {

            RuleFor(template => template.MessageTypeId)
                .SetValidator(new GuidValidator());

            RuleFor(template => template.Language)
                .SetValidator(new LanguageValidatior());

            RuleFor(template => template.Template)
                .SetValidator(new TemplateValidator());

            RuleFor(template => template.ModifiedByUserId)
                .SetValidator(new GuidValidator());
        }
    }
}
