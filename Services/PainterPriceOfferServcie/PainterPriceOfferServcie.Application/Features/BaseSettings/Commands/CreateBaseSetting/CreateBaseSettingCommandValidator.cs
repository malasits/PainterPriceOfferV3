using FluentValidation;

namespace PainterPriceOfferServcie.Application.Features.BaseSettings.Commands.CreateBaseSetting
{
    public class CreateBaseSettingCommandValidator : AbstractValidator<CreateBaseSettingCommand>
    {
        public CreateBaseSettingCommandValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty()
                .WithMessage("User ID is required.");

            RuleFor(x => x.DocumentTitle)
                .NotEmpty()
                .WithMessage("Document title is required.");

            RuleFor(x => x.AfaText)
                .NotEmpty()
                .WithMessage("Afa text is required.");

            RuleFor(x => x.NotAfaText)
                .NotEmpty()
                .WithMessage("Not afa text is required.");

            RuleFor(x => x.AfaKey)
                .NotEmpty()
                .WithMessage("Afa key is required.");
        }
    }
}
