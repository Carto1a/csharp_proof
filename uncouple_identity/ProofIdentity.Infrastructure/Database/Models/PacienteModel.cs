namespace ProofIdentity.Infrastructure.Database.Models;
public class PacienteModel : IEntityModel
{
    public Guid Id { get; set; }
    public DateTime CriadoEm { get; set; }

    public string Convenio { get; set; }
    public PessoaModel Pessoa { get; set; }
}