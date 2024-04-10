using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WasteControl.Application.Queries.Users.CheckUserPermision;
using WasteControl.Core.Enums;

namespace WasteControl.Api.Filters
{
    public class AutohorizationAttribute : AuthorizeAttribute, IAsyncAuthorizationFilter
    {
        private readonly UserRole _role;

        public AutohorizationAttribute(UserRole role)
        {
            _role = role;
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            Endpoint endpoint = context.HttpContext.GetEndpoint();
            if (endpoint?.Metadata?.GetMetadata<AllowAnonymousAttribute>() != null)
            {
                return;
            }

            string userId = context.HttpContext.User.Identity?.Name;

            if (string.IsNullOrEmpty(userId))
            {
                HandleUnauthorizedRequest(context);
                return;
            }

            IMediator mediator = context.HttpContext.RequestServices.GetService<IMediator>();            

            var hasPermission = await mediator.Send(new CheckUserPermisionQuery() { UserId = new Guid(userId), Role = _role });

            if (!hasPermission)
            {
                HandleUnauthorizedRequest(context);
                return;
            }
        }

        private void HandleUnauthorizedRequest(AuthorizationFilterContext context)
        {
            context.Result = new ForbidResult();
        }
    }
}