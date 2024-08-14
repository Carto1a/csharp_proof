namespace ProofIdentity.Infrastructure.Database.Models;
public class MedicoModel : IEntityModel
{
    public Guid Id { get; set; }
    public DateTime CriadoEm { get; set; }

    public string Crm { get; set; }
    public string UfCrm { get; set; }
    public PessoaModel Pessoa { get; set; }
}