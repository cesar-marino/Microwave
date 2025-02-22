using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microwave.Application.Services;
using Microwave.Domain.Exceptions;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Microwave.Infrastructure.Services.Token
{
    public class TokenService(IConfiguration configuration) : ITokenService
    {
        public async Task<string> GenerateTokenAsync(Guid id, string username, CancellationToken cancellationToken = default)
        {
            try
            {
                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:SecretKey"]!));
                _ = int.TryParse(configuration["JWT:AccessTokenValidityInMinutes"], out int accessTokenValidityInMinutes);

                var authClaims = new List<Claim>
                {
                    new(ClaimTypes.NameIdentifier, id.ToString()),
                    new(ClaimTypes.Name, username),
                    new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                var accessTokenExpiration = DateTime.Now.AddMinutes(accessTokenValidityInMinutes);

                var token = new JwtSecurityToken(
                    issuer: configuration["JWT:ValidIssuer"],
                    audience: configuration["JWT:ValidAudience"],
                    expires: accessTokenExpiration,
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256));

                var accessToken = new JwtSecurityTokenHandler().WriteToken(token);
                return await Task.Run(() => accessToken, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new UnexpectedException(innerException: ex);
            }
        }
    }
}
