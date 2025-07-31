using BuildingBlocks.Exceptions;
using Mapster;
using MediatR;
using PainterPriceOfferServcie.Application.Interfaces.Persistence;

namespace PainterPriceOfferServcie.Application.Features.BaseSettings.Commands.UpdateBaseSetting
{
    public class UpdateBaseSettingCommandHandler : IRequestHandler<UpdateBaseSettingCommand, Unit>
    {
        private readonly IBaseSettingRepository _baseSettingRepository;
        public UpdateBaseSettingCommandHandler(IBaseSettingRepository baseSettingRepository)
        {
            _baseSettingRepository = baseSettingRepository;
        }

        async Task<Unit> IRequestHandler<UpdateBaseSettingCommand, Unit>.Handle(UpdateBaseSettingCommand request, CancellationToken cancellationToken)
        {
            // Retrieve the existing base setting for the user
            var existingBaseSetting = await _baseSettingRepository.GetByUserIdAsync(request.UserId, cancellationToken);
            if (existingBaseSetting == null)
            {
                throw new NotFoundException($"Base setting with user id '{request.UserId}' not found.");
            }

            if (existingBaseSetting.Id != request.Id)
            {
                throw new BadRequestException($"Base setting id '{request.Id}' not match with user id '{request.UserId}'.");
            }

            // Update the existing base setting with new values
            request.Adapt(existingBaseSetting);

            // Save the updated base setting to the database
            await _baseSettingRepository.UpdateAsync(existingBaseSetting, cancellationToken);
            return Unit.Value;
        }
    }
}
