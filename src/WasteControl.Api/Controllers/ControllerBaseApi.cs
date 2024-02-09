using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WasteControl.Api.Controllers
{
    public class ControllerBaseApi : ControllerBase
    {
        protected readonly IMediator _mediator;

        public ControllerBaseApi(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}