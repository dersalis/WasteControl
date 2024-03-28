

using WasteControl.Auth;
using WasteControl.Infrastructure.Abstractions;

namespace WasteControl.Infrastructure.Auth
{
    public class Authenticator : IAuthenticator
    {
        public JwtDto CreateToken(Guid userId, string role)
        {
            throw new NotImplementedException();
        }
    }
}