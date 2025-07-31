using MapsterMapper;
using MediatR;
using PainterPriceOfferServcie.Application.Contracts.Responses.WorkUnit;
using PainterPriceOfferServcie.Application.Interfaces.Persistence;

namespace PainterPriceOfferServcie.Application.Features.WorkUnits.Queries.GetAllWorkUnit
{
    public class GetAllWorkUnitQueryHandler : IRequestHandler<GetAllWorkUnitQuery, IEnumerable<WorkUnitResponse>>
    {
        private readonly IWorkUnitRepository _workUnitRepository;
        private readonly IMapper _mapper;
        public GetAllWorkUnitQueryHandler(IWorkUnitRepository workUnitRepository, IMapper mapper)
        {
            _workUnitRepository = workUnitRepository;
            _mapper = mapper;
        }

        async Task<IEnumerable<WorkUnitResponse>> IRequestHandler<GetAllWorkUnitQuery, IEnumerable<WorkUnitResponse>>.Handle(GetAllWorkUnitQuery request, CancellationToken cancellationToken)
        {
            var workUnits = (await _workUnitRepository.GetAllByUserId(request.UserId, cancellationToken))
                .OrderBy(x => x.Name)
                .ToList();

            return _mapper.Map<IEnumerable<WorkUnitResponse>>(workUnits);
        }
    }
}
