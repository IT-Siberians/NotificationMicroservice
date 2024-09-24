using FluentValidation;

namespace NotificationMicroservice.Validator.Base
{
    public class UriValidator : AbstractValidator<Uri>
    {
        public UriValidator()
        {
            RuleFor(request => request)
                .NotNull()
                .NotEmpty();
        }
    }
}
