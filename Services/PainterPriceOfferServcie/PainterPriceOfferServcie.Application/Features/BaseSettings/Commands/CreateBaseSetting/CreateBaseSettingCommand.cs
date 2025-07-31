using MediatR;

namespace PainterPriceOfferServcie.Application.Features.BaseSettings.Commands.CreateBaseSetting
{
    public record CreateBaseSettingCommand(
        string UserId,
        string DocumentTitle,
        bool DefaultAfaSelected,
        string AfaText,
        string NotAfaText,
        int AfaKey
    ) : IRequest<Unit>;
}
