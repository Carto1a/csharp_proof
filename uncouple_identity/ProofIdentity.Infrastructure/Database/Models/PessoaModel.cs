using Microsoft.AspNetCore.Identity;

namespace ProofIdentity.Infrastructure.Database.Models;
public class PessoaModel : IdentityUser<Guid>, IEntityModel
{
    public string NomeCompleto { get; set; }
    public string CPF { get; set; }

    public DateTime CriadoEm { get; set; }
}