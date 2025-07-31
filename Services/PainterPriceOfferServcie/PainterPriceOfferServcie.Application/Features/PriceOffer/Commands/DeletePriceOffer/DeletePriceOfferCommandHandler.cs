using BuildingBlocks.Exceptions;
using MediatR;
using PainterPriceOfferServcie.Application.Interfaces.Persistence;

namespace PainterPriceOfferServcie.Application.Features.PriceOffer.Commands.DeletePriceOffer
{
    public class DeletePriceOfferCommandHandler : IRequestHandler<DeletePriceOfferCommand, Unit>
    {
        private readonly IPriceOfferRepository _priceOfferRepository;

        public DeletePriceOfferCommandHandler(IPriceOfferRepository priceOfferRepository)
        {
            _priceOfferRepository = priceOfferRepository;
        }

        public async Task<Unit> Handle(DeletePriceOfferCommand request, CancellationToken cancellationToken)
        {
            var priceOffer = await _priceOfferRepository.GetByIdAsync(request.Id, cancellationToken);
            if (priceOffer == null)
            {
                throw new NotFoundException($"Price offer with ID {request.Id} not found.");
            }
            priceOffer.IsDeleted = true;
            await _priceOfferRepository.UpdateAsync(priceOffer, cancellationToken);
            return Unit.Value;
        }
    }
}
