using MapsterMapper;
using MediatR;
using PainterPriceOfferServcie.Application.Contracts.Responses.MaterialUnit;
using PainterPriceOfferServcie.Application.Interfaces.Persistence;

namespace PainterPriceOfferServcie.Application.Features.MaterialUnits.Queries.GetAllMaterialUnit
{
    public class GetAllMaterialUnitQueryHandler : IRequestHandler<GetAllMaterialUnitQuery, IEnumerable<MaterialUnitResponse>>
    {
        private readonly IMaterialUnitRepository _materialUnitRepository;
        private readonly IMapper _mapper;
        public GetAllMaterialUnitQueryHandler(IMaterialUnitRepository materialUnitRepository, IMapper mapper)
        {
            _materialUnitRepository = materialUnitRepository;
            _mapper = mapper;
        }

        async Task<IEnumerable<MaterialUnitResponse>> IRequestHandler<GetAllMaterialUnitQuery, IEnumerable<MaterialUnitResponse>>.Handle(GetAllMaterialUnitQuery request, CancellationToken cancellationToken)
        {
            var materialUnits = (await _materialUnitRepository.GetAllByUserId(request.UserId, cancellationToken))
                .OrderBy(x => x.Name)
                .ToList();

            return _mapper.Map<IEnumerable<MaterialUnitResponse>>(materialUnits);
        }
    }
}
