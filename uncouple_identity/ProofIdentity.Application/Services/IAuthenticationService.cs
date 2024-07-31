using ProofIdentity.Domain;

namespace ProofIdentity.Application.Services;
public interface IAuthenService
{
    Task<string> Authenticate(BasicUser user);
    Task<string> Desauthenticate(BasicUser user);
}