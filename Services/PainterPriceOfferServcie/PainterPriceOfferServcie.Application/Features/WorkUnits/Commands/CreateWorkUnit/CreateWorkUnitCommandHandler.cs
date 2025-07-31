using FluentValidation;
using MediatR;
using PainterPriceOfferServcie.Application.Interfaces.Persistence;
using PainterPriceOfferServcie.Domain.Entity;

namespace PainterPriceOfferServcie.Application.Features.WorkUnits.Commands.CreateWorkUnit
{
    public class CreateWorkUnitCommandHandler : IRequestHandler<CreateWorkUnitCommand, Unit>
    {
        private readonly IWorkUnitRepository _workUnitRepository;
        public CreateWorkUnitCommandHandler(IWorkUnitRepository workUnitRepository)
        {
            _workUnitRepository = workUnitRepository;
        }

        public async Task<Unit> Handle(CreateWorkUnitCommand request, CancellationToken cancellationToken)
        {
            //Validate unique name before saving
            if (await _workUnitRepository.IsWorkUnitExistsByName(request.Name, cancellationToken: cancellationToken))
            {
                throw new ValidationException($"Work unit with name '{request.Name}' already exists.");
            }

            //Save the work unit to the database
            await _workUnitRepository.AddAsync(new WorkUnit
            {
                Name = request.Name,
                UserId = request.UserId,
                IsEnabledToEdit = true
            }, cancellationToken);

            return Unit.Value;
        }
    }
}
