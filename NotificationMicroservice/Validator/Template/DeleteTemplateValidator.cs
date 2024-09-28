using FluentValidation;
using NotificationMicroservice.Contracts.Template;
using NotificationMicroservice.Validator.Base;

namespace NotificationMicroservice.Validator.Template
{
    public class DeleteTemplateValidator : AbstractValidator<DeleteTemplateRequest>
    {
        public DeleteTemplateValidator()
        {
            RuleFor(template => template.ModifiedByUserId)
                .SetValidator(new GuidValidator());
        }
    }
}
