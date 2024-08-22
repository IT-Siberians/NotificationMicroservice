using FluentValidation;
using NotificationMicroservice.Contracts.Template;
using NotificationMicroservice.Validator.Base;

namespace NotificationMicroservice.Validator.Template
{
    public class TemplateDeleteValidator : AbstractValidator<TemplateDeleteRequest>
    {
        public TemplateDeleteValidator()
        {

            RuleFor(template => template.ModifyUserName)
                .SetValidator(new UserNameValidator());
        }
    }
}
