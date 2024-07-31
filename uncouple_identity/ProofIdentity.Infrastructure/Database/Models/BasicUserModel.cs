using Microsoft.AspNetCore.Identity;

namespace ProofIdentity.Infrastructure.Database.Models;
public class BasicUserModel : IdentityUser<Guid>
{
    public string NomeCompleto { get; set; }
    public DateOnly DataNascimento { get; set; }
    public string Cpf { get; set; }
    public DateTime CriadoEm { get; set; }
}