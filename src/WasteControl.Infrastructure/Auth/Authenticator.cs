

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using WasteControl.Auth;
using WasteControl.Infrastructure.Abstractions;

namespace WasteControl.Infrastructure.Auth
{
    public class Authenticator : IAuthenticator
    {
        private readonly string _issuer;
        private readonly string _audience;
        private readonly TimeSpan _expiry;
        private readonly SigningCredentials _signingCredentials;
        private readonly JwtSecurityTokenHandler _tokenHandler = new();

        public Authenticator(IOptions<AuthOptions> options)
        {
            _issuer = options.Value.Issuer;
            _audience = options.Value.Audience;
            _expiry = options.Value.Expiry ?? TimeSpan.FromHours(1);
            _signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.Value.SigningKey)), 
                SecurityAlgorithms.HmacSha256);
        }

        
        public JwtDto CreateToken(Guid userId, string role)
        {
            var now = DateTime.UtcNow;
            var expires = now.Add(_expiry);
            
            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Sub, userId.ToString()),
                new(JwtRegisteredClaimNames.UniqueName, userId.ToString()),
                new(ClaimTypes.Role, role),
            };

            var jwt = new JwtSecurityToken(
                _issuer,
                _audience,
                claims,
                now,
                expires,
                _signingCredentials
            );

            var accessToken = _tokenHandler.WriteToken(jwt);

            return new JwtDto
            {
                AccessToken = accessToken
            };
        }
    }
}