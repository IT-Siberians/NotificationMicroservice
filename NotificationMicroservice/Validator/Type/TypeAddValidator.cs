using FluentValidation;
using NotificationMicroservice.Contracts.Type;
using NotificationMicroservice.Validator.Base;

namespace NotificationMicroservice.Validator.Type
{
    public class TypeAddValidator : AbstractValidator<TypeAddRequest>
    {
        public TypeAddValidator()
        {

            RuleFor(type => type.Name)
                .SetValidator(new TypeNameValidator());

            RuleFor(type => type.CreateUserName)
                .SetValidator(new UserNameValidator());
        }
    }
}
