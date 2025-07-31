using MapsterMapper;
using MediatR;
using PainterPriceOfferServcie.Application.Contracts.Responses.WorkUnit;
using PainterPriceOfferServcie.Application.Interfaces.Persistence;

namespace PainterPriceOfferServcie.Application.Features.WorkUnits.Queries.GetAllActiveWorkUnit
{
    public class GetAllActiveWorkUnitQueryHandler : IRequestHandler<GetAllActiveWorkUnitQuery, IEnumerable<WorkUnitResponse>>
    {
        private readonly IWorkUnitRepository _workUnitRepository;
        private readonly IMapper _mapper;
        public GetAllActiveWorkUnitQueryHandler(IWorkUnitRepository workUnitRepository, IMapper mapper)
        {
            _workUnitRepository = workUnitRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<WorkUnitResponse>> Handle(GetAllActiveWorkUnitQuery request, CancellationToken cancellationToken)
        {
            var workUnits = (await _workUnitRepository.GetAllActiveByUserId(request.UserId, cancellationToken))
                .OrderBy(x => x.Name)
                .ToList();

            return _mapper.Map<IEnumerable<WorkUnitResponse>>(workUnits);
        }
    }
}
