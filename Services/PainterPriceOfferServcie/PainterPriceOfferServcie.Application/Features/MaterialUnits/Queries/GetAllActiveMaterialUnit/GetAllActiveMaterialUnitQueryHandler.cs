using MapsterMapper;
using MediatR;
using PainterPriceOfferServcie.Application.Contracts.Responses.MaterialUnit;
using PainterPriceOfferServcie.Application.Interfaces.Persistence;

namespace PainterPriceOfferServcie.Application.Features.MaterialUnits.Queries.GetAllActiveMaterialUnit
{
    public class GetAllActiveMaterialUnitQueryHandler : IRequestHandler<GetAllActiveMaterialUnitQuery, IEnumerable<MaterialUnitResponse>>
    {
        private readonly IMaterialUnitRepository _materialUnitRepository;
        private readonly IMapper _mapper;
        public GetAllActiveMaterialUnitQueryHandler(IMaterialUnitRepository materialUnitRepository, IMapper mapper)
        {
            _materialUnitRepository = materialUnitRepository;
            _mapper = mapper;
        }

        async Task<IEnumerable<MaterialUnitResponse>> IRequestHandler<GetAllActiveMaterialUnitQuery, IEnumerable<MaterialUnitResponse>>.Handle(GetAllActiveMaterialUnitQuery request, CancellationToken cancellationToken)
        {
            var materialUnits = (await _materialUnitRepository.GetAllActiveByUserId(request.UserId, cancellationToken))
                .OrderBy(x => x.Name)
                .ToList();

            return _mapper.Map<IEnumerable<MaterialUnitResponse>>(materialUnits);
        }
    }
}
