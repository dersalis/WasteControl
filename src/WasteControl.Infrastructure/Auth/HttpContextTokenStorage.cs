using WasteControl.Auth;
using WasteControl.Infrastructure.Abstractions;

namespace WasteControl.Infrastructure.Auth
{
    public class HttpContextTokenStorage : ITokenStorage
    {
        public JwtDto Get()
        {
            throw new NotImplementedException();
        }

        public void Set(JwtDto jwt)
        {
            throw new NotImplementedException();
        }
    }
}