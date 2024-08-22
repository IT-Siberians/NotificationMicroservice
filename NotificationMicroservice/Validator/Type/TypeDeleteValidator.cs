using FluentValidation;
using NotificationMicroservice.Contracts.Type;
using NotificationMicroservice.Validator.Base;

namespace NotificationMicroservice.Validator.Type
{
    public class TypeDeleteValidator : AbstractValidator<TypeDeleteRequest>
    {
        public TypeDeleteValidator()
        {

            RuleFor(type => type.ModifyUserName)
                .SetValidator(new UserNameValidator());
        }
    }
}
