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

        protected Guid? GetUserId()
        {
            string userName = HttpContext.User.Identity?.Name;

            if (Guid.TryParse(userName, out Guid userId))
            {
                return userId;
            }

            return null;
        }
    }
}