using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PainterPriceOfferServcie.Application.Contracts.Requests.PriceOffer;
using PainterPriceOfferServcie.Application.Features.PriceOffer.Commands.CreatePriceOffer;
using PainterPriceOfferServcie.Application.Features.PriceOffer.Commands.DeletePriceOffer;
using PainterPriceOfferServcie.Application.Features.PriceOffer.Commands.UpdatePriceOffer;
using PainterPriceOfferServcie.Application.Features.PriceOffer.Queries.GetAllActivePriceOffer;
using PainterPriceOfferServcie.Application.Features.PriceOffer.Queries.GetPriceOfferById;

namespace PainterPriceOfferServcie.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PriceOfferController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PriceOfferController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllActivePriceOfferToListByUserId")]
        public async Task<IActionResult> GetAllActivePriceOfferToListByUserId(string userId, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetAllActivePriceOfferToListQuery(userId), cancellationToken);
            return Ok(result);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(string id, string userId, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetPriceOfferByIdQuery(id, userId), cancellationToken);
            return Ok(result);
        }

        [HttpPost("CreatePriceOffer")]
        public async Task<IActionResult> CreatePriceOffer([FromBody] CreatePriceOfferRequest request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request.Adapt<CreatePriceOfferCommand>(), cancellationToken);
            return Ok(result);
        }

        [HttpPut("UpdatePriceOffer")]
        public async Task<IActionResult> UpdatePriceOffer([FromBody] UpdatePriceOfferRequest request, CancellationToken cancellationToken)
        {
            var command = request.Adapt<UpdatePriceOfferCommand>() with { IsDeleted = false };
            await _mediator.Send(command, cancellationToken);
            return Ok();
        }

        [HttpDelete("DeletePriceOffer")]
        public async Task<IActionResult> DeletePriceOffer(string id, CancellationToken cancellationToken)
        {
            var command = new DeletePriceOfferCommand(id);
            await _mediator.Send(command, cancellationToken);
            return Ok();
        }
    }
}
