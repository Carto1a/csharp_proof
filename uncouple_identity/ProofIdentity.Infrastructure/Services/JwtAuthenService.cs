using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using ProofIdentity.Application.Services;
using ProofIdentity.Domain;

namespace ProofIdentity.Infrastructure.Services;
public class JwtAuthenService : IAuthenService
{
    private readonly string _jwtSecret;
    private readonly string _jwtValidIssuer;
    private readonly string _jwtValidAudience;
    private readonly TimeSpan _timeToExpire;

    public JwtAuthenService(
        string jwtSecret,
        string jwtValidIssuer,
        string jwtValidAudience,
        TimeSpan timeToExpire)
    {
        _jwtSecret = jwtSecret;
        _jwtValidIssuer = jwtValidIssuer;
        _jwtValidAudience = jwtValidAudience;
        _timeToExpire = timeToExpire;
    }

    public Task<string> Authenticate(BasicUser user)
    {
        var authClaims = new List<Claim>
        {
            new("ID", user.Id.ToString()),
            new(ClaimTypes.Name, user.NameCompleto),
            new(ClaimTypes.Email, user.Email),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var token = GenerateToken(authClaims);

        var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
        return Task.FromResult(tokenString);
    }

    public Task<string> Desauthenticate(BasicUser user)
    {
        throw new NotImplementedException();
    }

    public JwtSecurityToken GenerateToken(IEnumerable<Claim> authClaims)
    {
        var authSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_jwtSecret));

        return new JwtSecurityToken(
            issuer: _jwtValidIssuer,
            audience: _jwtValidAudience,
            expires: DateTime.Now.Add(_timeToExpire),
            claims: authClaims,
            signingCredentials:
                new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
        );
    }
}
