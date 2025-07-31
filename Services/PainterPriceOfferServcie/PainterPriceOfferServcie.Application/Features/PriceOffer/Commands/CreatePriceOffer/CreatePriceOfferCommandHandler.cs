using Mapster;
using MediatR;
using PainterPriceOfferServcie.Application.Interfaces.Persistence;

namespace PainterPriceOfferServcie.Application.Features.PriceOffer.Commands.CreatePriceOffer
{
    public class CreatePriceOfferCommandHandler : IRequestHandler<CreatePriceOfferCommand, Unit>
    {
        private readonly IPriceOfferRepository _priceOfferRepository;

        public CreatePriceOfferCommandHandler(IPriceOfferRepository priceOfferRepository)
        {
            _priceOfferRepository = priceOfferRepository;
        }

        public async Task<Unit> Handle(CreatePriceOfferCommand request, CancellationToken cancellationToken)
        {
            var priceOffer = request.Adapt<Domain.Entity.PriceOffer>();
            await _priceOfferRepository.AddAsync(priceOffer, cancellationToken);
            return Unit.Value;
        }
    }
}
