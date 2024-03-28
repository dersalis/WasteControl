
using WasteControl.Auth;

namespace WasteControl.Infrastructure.Abstractions
{
    public interface ITokenStorage
    {
        void Set(JwtDto jwt);
        JwtDto Get();
    }
}