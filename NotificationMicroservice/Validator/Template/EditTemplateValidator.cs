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
                .NotEmpty();

            RuleFor(template => template.Language)
                .SetValidator(new LanguageValidatior());

            RuleFor(template => template.Template)
                .SetValidator(new TemplateValidator());

            RuleFor(template => template.ModifiedUserName)
                .SetValidator(new UserNameValidator());
        }
    }
}
