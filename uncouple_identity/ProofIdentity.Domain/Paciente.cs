namespace ProofIdentity.Domain;
public class Paciente : Entity
{
    public string Convenio { get; set; }
    public Pessoa Pessoa { get; set; }

    private Paciente() { }

    public Paciente(string convenio, string nomeCompleto, string cpf)
    {
        Convenio = convenio;
        Pessoa = new Pessoa(nomeCompleto, cpf);
    }
}