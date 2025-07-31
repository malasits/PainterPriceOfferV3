using FluentValidation;

namespace PainterPriceOfferServcie.Application.Features.BaseSettings.Queries.GetUserSettings
{
    public class GetUserSettingsQueryValidator : AbstractValidator<GetUserSettingsQuery>
    {
        public GetUserSettingsQueryValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("UserId is required.");
        }
    }

}
