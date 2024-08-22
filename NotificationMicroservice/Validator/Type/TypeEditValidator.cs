using FluentValidation;
using NotificationMicroservice.Contracts.Type;
using NotificationMicroservice.Validator.Base;

namespace NotificationMicroservice.Validator.Type
{
    public class TypeEditValidator : AbstractValidator<TypeEditRequest>
    {
        public TypeEditValidator()
        {

            RuleFor(type => type.Name)
                .SetValidator(new TypeNameValidator());

            RuleFor(type => type.ModifyUserName)
                .SetValidator(new UserNameValidator());
        }
    }
}
