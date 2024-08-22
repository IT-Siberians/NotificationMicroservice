using FluentValidation;
using NotificationMicroservice.Contracts.Template;
using NotificationMicroservice.Validator.Base;

namespace NotificationMicroservice.Validator.Template
{
    public class TemplateAddValidator : AbstractValidator<TemplateAddRequest>
    {
        public TemplateAddValidator()
        {

            RuleFor(template => template.MessageTypeId)
                .NotEmpty();

            RuleFor(template => template.Language)
                .SetValidator(new LanguageValidatior());

            RuleFor(template => template.Template)
                .SetValidator(new TemplateValidator());

            RuleFor(template => template.CreateUserName)
                .SetValidator(new UserNameValidator());
        }
    }
}
