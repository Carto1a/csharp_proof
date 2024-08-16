using ProofIdentity.Application.DTOs.Logins;
using ProofIdentity.Domain;

namespace ProofIdentity.Application.Mapper;
public static class LoginMapper
{
    public static Pessoa ToCheck(this LoginDto request)
    {
        return new Pessoa()
        {
            CPF = request.CPF
        };
    }
}