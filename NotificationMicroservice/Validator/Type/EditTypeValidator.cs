using FluentValidation;
using NotificationMicroservice.Contracts.Type;
using NotificationMicroservice.Validator.Base;

namespace NotificationMicroservice.Validator.Type
{
    public class EditTypeValidator : AbstractValidator<EditTypeRequest>
    {
        public EditTypeValidator()
        {

            RuleFor(type => type.Name)
                .SetValidator(new TypeNameValidator());

            RuleFor(type => type.ModifiedUserName)
                .SetValidator(new UserNameValidator());
        }
    }
}
