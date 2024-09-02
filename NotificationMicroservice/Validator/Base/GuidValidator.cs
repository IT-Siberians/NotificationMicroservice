using FluentValidation;

namespace NotificationMicroservice.Validator.Base
{
    public class GuidValidator : AbstractValidator<Guid>
    {
        public GuidValidator()
        {
            RuleFor(x => x)
                .NotEmpty();
        }
    }
}
