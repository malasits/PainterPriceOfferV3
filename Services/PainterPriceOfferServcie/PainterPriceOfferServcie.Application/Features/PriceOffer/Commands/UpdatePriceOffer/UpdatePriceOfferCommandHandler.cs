using BuildingBlocks.Exceptions;
using Mapster;
using MediatR;
using PainterPriceOfferServcie.Application.Interfaces.Persistence;

namespace PainterPriceOfferServcie.Application.Features.PriceOffer.Commands.UpdatePriceOffer
{
    public class UpdatePriceOfferCommandHandler : IRequestHandler<UpdatePriceOfferCommand, Unit>
    {
        private readonly IPriceOfferRepository _priceOfferRepository;

        public UpdatePriceOfferCommandHandler(IPriceOfferRepository priceOfferRepository)
        {
            _priceOfferRepository = priceOfferRepository;
        }

        public async Task<Unit> Handle(UpdatePriceOfferCommand request, CancellationToken cancellationToken)
        {
            var priceOffer = await _priceOfferRepository.GetByIdAsync(request.Id, cancellationToken);
            if (priceOffer == null)
            {
                throw new NotFoundException($"Price offer with ID {request.Id} not found.");
            }

            priceOffer = request.Adapt(priceOffer);
            await _priceOfferRepository.UpdateAsync(priceOffer, cancellationToken);
            return Unit.Value;
        }
    }
}
