using ProofIdentity.Domain;

namespace ProofIdentity.Application.Services;
public interface ILoginService
{
    Task<Guid> Register(Paciente user, string password);
    Task<Guid> Register(Admin user, string password);
    Task<Guid> Register(Medico user, string password);

    Task<bool> CheckIfLoginExistAsync(Admin user);
    Task<bool> CheckIfLoginExistAsync(Paciente user);
    Task<bool> CheckIfLoginExistAsync(Medico user);

    Task<bool> CheckIfLoginExistAsync(Pessoa user);
    Task<bool> CheckPasswordAsync(Pessoa user, string password);

    Task<Guid> Register(BasicUser user, string password);
    Task<bool> CheckIfLoginExistAsync(BasicUser user);
    Task<bool> CheckPasswordAsync(BasicUser user, string password);
}