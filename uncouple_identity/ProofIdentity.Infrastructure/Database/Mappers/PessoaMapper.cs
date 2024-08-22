using ProofIdentity.Domain;
using ProofIdentity.Infrastructure.Database.Models;

namespace ProofIdentity.Infrastructure.Mappers;
public static class PessoaMapper
{
    public static PessoaModel ToLoginModel(this Pessoa pessoa)
    {
        return new PessoaModel()
        {
            Id = pessoa.Id,
            NomeCompleto = pessoa.NomeCompleto,
            CPF = pessoa.CPF,
            UserName = pessoa.CPF,
            SecurityStamp = pessoa.SecurityStamp.ToString()
        };
    }
}