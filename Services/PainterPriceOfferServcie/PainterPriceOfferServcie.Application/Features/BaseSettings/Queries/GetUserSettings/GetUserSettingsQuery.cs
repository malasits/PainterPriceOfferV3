using MediatR;
using PainterPriceOfferServcie.Application.Contracts.Responses.BaseSetting;

namespace PainterPriceOfferServcie.Application.Features.BaseSettings.Queries.GetUserSettings
{
    public record GetUserSettingsQuery(string UserId) : IRequest<BaseSettingResponse>;
}
