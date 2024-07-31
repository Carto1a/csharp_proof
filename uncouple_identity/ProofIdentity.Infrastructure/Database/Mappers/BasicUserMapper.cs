using ProofIdentity.Domain;
using ProofIdentity.Infrastructure.Database.Models;

namespace ProofIdentity.Infrastructure.Mappers;
public static class BasicUserMapper
{
    public static BasicUserModel ToModel(this BasicUser user)
    {
        return new BasicUserModel()
        {
            Id = user.Id,
            UserName = user.UserName,
            NomeCompleto = user.NameCompleto,
            Email = user.Email,
            DataNascimento = user.DataNascimento,
            Cpf = user.Cpf,
            CriadoEm = user.CriadoEm
        };
    }

    /* public static BasicUser ToDomain(BasicUserModel user) */
    /* { */
    /*     return new BasicUser() */
    /*     { */
    /*         Id = user.Id, */
    /*         UserName = user.UserName ?? string.Empty, */
    /*         NameCompleto = user.NomeCompleto, */
    /*         Email = user.Email ?? string.Empty, */
    /*         DataNascimento = user.DataNascimento, */
    /*         Cpf = user.Cpf, */
    /*         CriadoEm = user.CriadoEm */
    /*     }; */
    /* } */

    public static BasicUser ToDomain(this BasicUserModel user)
    {
        return new BasicUser()
        {
            Id = user.Id,
            UserName = user.UserName ?? string.Empty,
            NameCompleto = user.NomeCompleto,
            Email = user.Email ?? string.Empty,
            DataNascimento = user.DataNascimento,
            Cpf = user.Cpf,
            CriadoEm = user.CriadoEm
        };
    }
}