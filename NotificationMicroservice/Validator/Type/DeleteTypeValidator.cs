using FluentValidation;
using NotificationMicroservice.Contracts.Type;
using NotificationMicroservice.Validator.Base;

namespace NotificationMicroservice.Validator.Type
{
    public class DeleteTypeValidator : AbstractValidator<DeleteTypeRequest>
    {
        public DeleteTypeValidator()
        {
            RuleFor(type => type.ModifiedByUserId)
                .SetValidator(new GuidValidator());
        }
    }
}
