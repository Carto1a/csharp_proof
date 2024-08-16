
namespace ProofIdentity.Infrastructure.Database.Models;
public class AdminModel : IEntityModel
{
    public Guid Id { get; set; }
    public DateTime CriadoEm { get; set; }

    public string Info { get; set; }
    public PessoaModel? Pessoa { get; set; }
}