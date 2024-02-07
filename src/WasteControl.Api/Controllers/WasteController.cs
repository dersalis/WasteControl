using MediatR;
using Microsoft.AspNetCore.Mvc;
using WasteControl.Application.Queries.GetWastes;

namespace WasteControl.Api.Controllers
{
    [ApiController]
    [Route("wastes")]
    public class WasteController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WasteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var wastes = await _mediator.Send(new GetWastesQuery());

            return Ok(wastes);
        }
    }
}