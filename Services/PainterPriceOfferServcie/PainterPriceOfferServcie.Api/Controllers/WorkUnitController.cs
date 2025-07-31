using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PainterPriceOfferServcie.Application.Contracts.Requests.WorkUnit;
using PainterPriceOfferServcie.Application.Features.WorkUnits.Commands.CreateWorkUnit;
using PainterPriceOfferServcie.Application.Features.WorkUnits.Commands.DeleteWorkUnit;
using PainterPriceOfferServcie.Application.Features.WorkUnits.Commands.UpdateWorkUnit;
using PainterPriceOfferServcie.Application.Features.WorkUnits.Queries.GetAllActiveWorkUnit;
using PainterPriceOfferServcie.Application.Features.WorkUnits.Queries.GetAllWorkUnit;
namespace PainterPriceOfferServcie.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkUnitController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WorkUnitController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllWorkUnitByUserId")]
        public async Task<IActionResult> GetAllWorkUnitByUserId(string userId, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetAllWorkUnitQuery(userId), cancellationToken);
            return Ok(result);
        }

        [HttpGet("GetAllActiveWorkUnitByUserId")]
        public async Task<IActionResult> GetAllActiveWorkUnitByUserId(string userId, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetAllActiveWorkUnitQuery(userId), cancellationToken);
            return Ok(result);
        }

        [HttpPost("CreateWorkUnit")]
        public async Task<IActionResult> CreateWorkUnit([FromBody] CreateWorkUnitRequest request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request.Adapt<CreateWorkUnitCommand>(), cancellationToken);
            return Ok(result);
        }

        [HttpPut("UpdateWorkUnit")]
        public async Task<IActionResult> UpdateWorkUnit([FromBody] UpdateWorkUnitRequest request, CancellationToken cancellationToken)
        {
            var command = request.Adapt<UpdateWorkUnitCommand>() with { IsDeleted = false };
            await _mediator.Send(command, cancellationToken);
            return Ok();
        }

        [HttpDelete("DeleteWorkUnit")]
        public async Task<IActionResult> DeleteWorkUnit(string id, CancellationToken cancellationToken)
        {
            var command = new DeleteWorkUnitCommand(id);
            await _mediator.Send(command, cancellationToken);
            return Ok();
        }
    }
}
