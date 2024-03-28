using WasteControl.Auth;

namespace WasteControl.Infrastructure.Abstractions
{
    public interface IAuthenticator
    {
        JwtDto CreateToken(Guid userId, string role);
    }
}