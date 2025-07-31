using MediatR;
using Mapster;
using PainterPriceOfferServcie.Application.Interfaces.Persistence;
using BuildingBlocks.Exceptions;

namespace PainterPriceOfferServcie.Application.Features.BaseSettings.Commands.CreateBaseSetting
{
    public class CreateBaseSettingCommandHandler : IRequestHandler<CreateBaseSettingCommand, Unit>
    {
        private readonly IBaseSettingRepository _baseSettingRepository;
        public CreateBaseSettingCommandHandler(IBaseSettingRepository baseSettingRepository)
        {
            _baseSettingRepository = baseSettingRepository;
        }

        public async Task<Unit> Handle(CreateBaseSettingCommand request, CancellationToken cancellationToken)
        {
            // Check if a base setting already exists for the user
            var existingBaseSetting = await _baseSettingRepository.GetByUserIdAsync(request.UserId, cancellationToken);
            if (existingBaseSetting != null)
            {
                // If a base setting already exists, throw an exception
                throw new BadRequestException("Base setting already exists for this user.");
            }

            var baseSetting = request.Adapt<Domain.Entity.BaseSettings>();
            await _baseSettingRepository.AddAsync(baseSetting, cancellationToken);
            return Unit.Value;
        }
    }
}
