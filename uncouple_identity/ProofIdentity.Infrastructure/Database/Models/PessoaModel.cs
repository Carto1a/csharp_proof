using Microsoft.AspNetCore.Identity;

namespace ProofIdentity.Infrastructure.Database.Models;
public class PessoaModel : IdentityUser<Guid>
{
    public string NomeCompleto { get; set; }
    public string CPF { get; set; }
}