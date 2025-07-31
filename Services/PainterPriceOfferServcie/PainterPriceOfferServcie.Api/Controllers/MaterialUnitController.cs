using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PainterPriceOfferServcie.Application.Contracts.Requests.MaterialUnit;
using PainterPriceOfferServcie.Application.Features.MaterialUnits.Commands.CreateMaterialUnit;
using PainterPriceOfferServcie.Application.Features.MaterialUnits.Commands.DeleteMaterialUnit;
using PainterPriceOfferServcie.Application.Features.MaterialUnits.Commands.UpdateMaterialUnit;
using PainterPriceOfferServcie.Application.Features.MaterialUnits.Queries.GetAllActiveMaterialUnit;
using PainterPriceOfferServcie.Application.Features.MaterialUnits.Queries.GetAllMaterialUnit;

namespace PainterPriceOfferServcie.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialUnitController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MaterialUnitController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllMaterialUnitByUserId")]
        public async Task<IActionResult> GetAllMaterialUnitByUserId(string userId, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetAllMaterialUnitQuery(userId), cancellationToken);
            return Ok(result);
        }

        [HttpGet("GetAllActiveMaterialUnitByUserId")]
        public async Task<IActionResult> GetAllActiveMaterialUnitByUserId(string userId, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetAllActiveMaterialUnitQuery(userId), cancellationToken);
            return Ok(result);
        }

        [HttpPost("CreateMaterialUnit")]
        public async Task<IActionResult> CreateMaterialUnit([FromBody] CreateMaterialUnitRequest request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request.Adapt<CreateMaterialUnitCommand>(), cancellationToken);
            return Ok(result);
        }

        [HttpPut("UpdateMaterialUnit")]
        public async Task<IActionResult> UpdateMaterialUnit([FromBody] UpdateMaterialUnitRequest request, CancellationToken cancellationToken)
        {
            var command = request.Adapt<UpdateMaterialUnitCommand>() with { IsDeleted = false };
            await _mediator.Send(command, cancellationToken);
            return Ok();
        }

        [HttpDelete("DeleteMaterialUnit")]
        public async Task<IActionResult> DeleteMaterialUnit(string id, CancellationToken cancellationToken)
        {
            var command = new DeleteMaterialUnitCommand(id);
            await _mediator.Send(command, cancellationToken);
            return Ok();
        }
    }
}
