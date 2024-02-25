using FluentValidation;

namespace iPractice.ApiModels.Validators
{
    public class AvailabilityRequestValidator : AbstractValidator<AvailabilityRequest>
    {
        public AvailabilityRequestValidator()
        {
            RuleFor(request => request.From)
                .NotEmpty().WithMessage("From date is required.")
                .LessThan(request => request.To).WithMessage("From date must be before To date.");

            RuleFor(request => request.To)
                .NotEmpty().WithMessage("To date is required.")
                .GreaterThan(request => request.From).WithMessage("To date must be after From date.");
            // Add more rules for other properties as needed...
        }
    }
}
