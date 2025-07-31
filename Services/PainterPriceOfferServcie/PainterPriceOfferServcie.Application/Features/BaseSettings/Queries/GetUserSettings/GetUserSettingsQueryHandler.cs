using Mapster;
using MediatR;
using PainterPriceOfferServcie.Application.Contracts.Responses.BaseSetting;
using PainterPriceOfferServcie.Application.Interfaces.Persistence;

namespace PainterPriceOfferServcie.Application.Features.BaseSettings.Queries.GetUserSettings
{
    public class GetUserSettingsQueryHandler : IRequestHandler<GetUserSettingsQuery, BaseSettingResponse>
    {
        private readonly IBaseSettingRepository _baseSettingRepository;
        public GetUserSettingsQueryHandler(IBaseSettingRepository baseSettingRepository)
        {
            _baseSettingRepository = baseSettingRepository;
        }

        public async Task<BaseSettingResponse> Handle(GetUserSettingsQuery request, CancellationToken cancellationToken)
        {
            var baseSetting = await _baseSettingRepository.GetByUserIdAsync(request.UserId, cancellationToken);
            return baseSetting.Adapt<BaseSettingResponse>();
        }
    }
}
