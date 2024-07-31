using ProofIdentity.Domain;

namespace ProofIdentity.Application.Services;
public interface ILoginService
{
    Task<Guid> Register(BasicUser user, string password);
    Task<bool> CheckIfLoginExistAsync(BasicUser user);
    Task<bool> CheckPasswordAsync(BasicUser user, string password);
}