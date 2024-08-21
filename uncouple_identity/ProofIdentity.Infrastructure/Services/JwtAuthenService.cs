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

    public Task<string> Authenticate(Admin user)
    {
        throw new NotImplementedException();
    }

    public Task<string> Authenticate(Paciente user)
    {
        throw new NotImplementedException();
    }

    public Task<string> Authenticate(Medico user)
    {
        throw new NotImplementedException();
    }

    public Task<string> Desauthenticate(Pessoa user)
    {
        throw new NotImplementedException();
    }
}