using System.Net.Http.Headers;
using Microsoft.Extensions.Options;
using WasteControl.Auth;
using WasteControl.Core.Enums;
using WasteControl.Infrastructure.Abstractions;
using WasteControl.Infrastructure.Auth;

namespace WasteControl.Tests.Integration.Controllers
{
    [Collection("api")]
    public abstract class ControllerTest : IClassFixture<OptionsProvider>
    {
        private readonly IAuthenticator _authenticator;
        protected HttpClient Client { get; }

        protected ControllerTest(OptionsProvider optionsProvider)
        {
            var authOprions = optionsProvider.Get<AuthOptions>("auth");
            _authenticator = new Authenticator(new OptionsWrapper<AuthOptions>(authOprions));

            var app = new WasteControlTestApp();
            Client = app.Client;
        }

        protected JwtDto Authorize(Guid userId, string role)
        {
            var jwt = _authenticator.CreateToken(userId, role);
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt.AccessToken);

            return jwt;
        }
    }
}