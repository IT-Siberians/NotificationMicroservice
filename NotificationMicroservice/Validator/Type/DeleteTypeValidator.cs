using FluentValidation;
using NotificationMicroservice.Contracts.Type;
using NotificationMicroservice.Validator.Base;

namespace NotificationMicroservice.Validator.Type
{
    public class DeleteTypeValidator : AbstractValidator<DeleteTypeRequest>
    {
        public DeleteTypeValidator()
        {

            RuleFor(type => type.ModifiedUserId)
                .SetValidator(new GuidValidator());
        }
    }
}
