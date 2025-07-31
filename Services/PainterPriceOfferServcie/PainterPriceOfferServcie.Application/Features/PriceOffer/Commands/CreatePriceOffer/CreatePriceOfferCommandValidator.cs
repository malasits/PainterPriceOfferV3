using FluentValidation;

namespace PainterPriceOfferServcie.Application.Features.PriceOffer.Commands.CreatePriceOffer
{
    public class CreatePriceOfferCommandValidator : AbstractValidator<CreatePriceOfferCommand>
    {
        public CreatePriceOfferCommandValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("User ID is required.");

            RuleFor(x => x.DocumentTitle)
                .NotEmpty().WithMessage("Document title is required.");

            RuleFor(x => x.JobTitle)
                .NotEmpty().WithMessage("Job title is required.");

            RuleFor(x => x.PriceOfferDate)
                .NotEmpty().WithMessage("Price offer date is required.")
                .LessThanOrEqualTo(DateTime.Today.AddDays(1)).WithMessage("Price offer date cannot be far in the future.");

            RuleFor(x => x.NameOfSettlement)
                .NotEmpty().WithMessage("Settlement name is required.");

            // Supplier
            RuleFor(x => x.SupplierName)
                .NotEmpty().WithMessage("Supplier name is required.");
            RuleFor(x => x.SupplierAddress)
                .NotEmpty().WithMessage("Supplier address is required.");
            RuleFor(x => x.SupplierPhone)
                .NotEmpty().WithMessage("Supplier phone is required.");
            RuleFor(x => x.SupplierEmail)
                .NotEmpty().WithMessage("Supplier email is required.")
                .EmailAddress().WithMessage("Supplier email must be valid.");

            // Customer
            RuleFor(x => x.CustomerName)
                .NotEmpty().WithMessage("Customer name is required.");
            RuleFor(x => x.CustomerAddress)
                .NotEmpty().WithMessage("Customer address is required.");
            RuleFor(x => x.CustomerPhone)
                .NotEmpty().WithMessage("Customer phone is required.");
            RuleFor(x => x.CustomerEmail)
                .NotEmpty().WithMessage("Customer email is required.")
                .EmailAddress().WithMessage("Customer email must be valid.");

            // AFA
            RuleFor(x => x.AfaKey)
                .GreaterThanOrEqualTo(0).WithMessage("AFA kulcs nem lehet negatív.");

            // Work wages
            RuleFor(x => x.WorkWages)
                .NotNull().WithMessage("Work wages are required.");

            // Material wages
            RuleFor(x => x.MaterialWages)
                .NotNull().WithMessage("Material wages are required.");
        }
    }
}
