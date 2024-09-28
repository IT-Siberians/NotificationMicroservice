using FluentValidation;
using NotificationMicroservice.Contracts.Type;
using NotificationMicroservice.Validator.Base;

namespace NotificationMicroservice.Validator.Type
{
    public class AddTypeValidator : AbstractValidator<AddTypeRequest>
    {
        public AddTypeValidator()
        {
            RuleFor(type => type.Name)
                .SetValidator(new TypeNameValidator());

            RuleFor(type => type.CreatedByUserId)
                .SetValidator(new GuidValidator());
        }
    }
}
