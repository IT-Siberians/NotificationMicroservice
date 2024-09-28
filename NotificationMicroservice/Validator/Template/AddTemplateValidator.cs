﻿using FluentValidation;
using NotificationMicroservice.Contracts.Template;
using NotificationMicroservice.Validator.Base;

namespace NotificationMicroservice.Validator.Template
{
    public class AddTemplateValidator : AbstractValidator<AddTemplateRequest>
    {
        public AddTemplateValidator()
        {

            RuleFor(template => template.MessageTypeId)
                .SetValidator(new GuidValidator());

            RuleFor(template => template.Language)
                .SetValidator(new LanguageValidatior());

            RuleFor(template => template.Template)
                .SetValidator(new TemplateValidator());

            RuleFor(template => template.CreatedByUserId)
                .SetValidator(new GuidValidator());
        }
    }
}
