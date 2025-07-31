using MapsterMapper;
using MediatR;
using PainterPriceOfferServcie.Application.Contracts.Responses.PriceOffer;
using PainterPriceOfferServcie.Application.Interfaces.Persistence;

namespace PainterPriceOfferServcie.Application.Features.PriceOffer.Queries.GetPriceOfferById
{
    public class GetPriceOfferByIdQueryHandler : IRequestHandler<GetPriceOfferByIdQuery, PriceOfferResponse>
    {
        private readonly IPriceOfferRepository _priceOfferRepository;
        private readonly IMapper _mapper;

        public GetPriceOfferByIdQueryHandler(
            IPriceOfferRepository priceOfferRepository,
            IMapper mapper
            )
        {
            _priceOfferRepository = priceOfferRepository;
            _mapper = mapper;
        }

        public async Task<PriceOfferResponse> Handle(GetPriceOfferByIdQuery request, CancellationToken cancellationToken)
        {
            var priceOffer = await _priceOfferRepository.GetByIdAndUserId(request.Id, request.UserId, cancellationToken);
            if (priceOffer == null)
            {
                throw new KeyNotFoundException($"Price offer with ID {request.Id} not found.");
            }
            return _mapper.Map<PriceOfferResponse>(priceOffer);
        }
    }
}
