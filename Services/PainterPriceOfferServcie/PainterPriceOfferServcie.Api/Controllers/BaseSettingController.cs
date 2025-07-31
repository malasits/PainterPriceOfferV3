using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PainterPriceOfferServcie.Application.Contracts.Requests.BaseSetting;
using PainterPriceOfferServcie.Application.Features.BaseSettings.Commands.CreateBaseSetting;

namespace PainterPriceOfferServcie.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseSettingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BaseSettingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //[HttpGet("GetUserSettings")]
        //public async Task<IActionResult> GetUserSettings(string userId, CancellationToken cancellationToken)
        //{
        //    var result = await _mediator.Send(new GetPriceOfferByIdQuery(id, userId), cancellationToken);
        //    return Ok(result);
        //}

        [HttpPost("CreateBaseSetting")]
        public async Task<IActionResult> CreateBaseSetting([FromBody] CreateBaseSettingRequest request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request.Adapt<CreateBaseSettingCommand>(), cancellationToken);
            return Ok(result);
        }

        //[HttpPut("UpdateBaseSetting")]
        //public async Task<IActionResult> UpdateBaseSetting([FromBody] UpdateBaseSettingRequest request, CancellationToken cancellationToken)
        //{
        //    var command = request.Adapt<UpdateBaseSettingCommand>();
        //    await _mediator.Send(command, cancellationToken);
        //    return Ok();
        //}
    }
}
