using ProofIdentity.Domain;

namespace ProofIdentity.Application.Repositories;
public interface ILoginRepository
{
    Task<bool> LoginExistAsync(Pessoa user);
    Task<bool> IsPasswordCorrectAsync(Pessoa user, string password);
    Task AddToRoleAsync(Pessoa user, Roles role);
}