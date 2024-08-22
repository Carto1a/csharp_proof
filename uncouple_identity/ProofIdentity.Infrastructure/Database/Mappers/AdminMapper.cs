using ProofIdentity.Domain;
using ProofIdentity.Infrastructure.Database.Models;

namespace ProofIdentity.Infrastructure.Mappers;
public static class AdminMapper
{
    public static AdminModel ToModel(this Admin admin)
    {
        return new AdminModel()
        {
            Id = admin.Id,
            Pessoa = new PessoaModel()
            {
                Id = admin.Id,
                NomeCompleto = admin.NomeCompleto,
                CPF = admin.CPF,
                UserName = admin.CPF,
                SecurityStamp = admin.SecurityStamp.ToString()
            },
        };
    }
}