using ProofIdentity.Domain;

namespace ProofIdentity.Application.Services;
public interface IAuthenService
{
    Task<string> Authenticate(Admin user);
    Task<string> Authenticate(Paciente user);
    Task<string> Authenticate(Medico user);

    Task<string> Desauthenticate(Pessoa user);
}