using MapsterMapper;
using MediatR;
using PainterPriceOfferServcie.Application.Contracts.Responses.PriceOffer;
using PainterPriceOfferServcie.Application.Interfaces.Persistence;

namespace PainterPriceOfferServcie.Application.Features.PriceOffer.Queries.GetAllActivePriceOffer
{
    public class GetAllActivePriceOfferToListQueryHandler : IRequestHandler<GetAllActivePriceOfferToListQuery, IEnumerable<PriceOfferListResponse>>
    {
        private readonly IPriceOfferRepository _priceOfferRepository;
        private readonly IMapper _mapper;

        public GetAllActivePriceOfferToListQueryHandler(
            IPriceOfferRepository priceOfferRepository,
            IMapper mapper
            )
        {
            _priceOfferRepository = priceOfferRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PriceOfferListResponse>> Handle(GetAllActivePriceOfferToListQuery request, CancellationToken cancellationToken)
        {
            var priceOffers = (await _priceOfferRepository.GetAllActiveByUserIdToList(request.UserId, cancellationToken))
                .OrderBy(x=>x.Created)
                .ToList();

            return _mapper.Map<IEnumerable<PriceOfferListResponse>>(priceOffers);
        }
    }
}
