using MediatR;

namespace PainterPriceOfferServcie.Application.Features.BaseSettings.Commands.UpdateBaseSetting
{
    public record UpdateBaseSettingCommand(
        string Id,
        string UserId,
        string DocumentTitle,
        bool DefaultAfaSelected,
        string AfaText,
        string NotAfaText,
        int AfaKey
    ) : IRequest<Unit>;
}
