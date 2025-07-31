using FluentValidation;

namespace PainterPriceOfferServcie.Application.Features.BaseSettings.Commands.UpdateBaseSetting
{
    public class UpdateBaseSettingCommandValidator : AbstractValidator<UpdateBaseSettingCommand>
    {
        public UpdateBaseSettingCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Base setting ID is required.");

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
