namespace ProofIdentity.Domain;
public class Paciente : Pessoa
{
    public string Convenio { get; set; }
    public Pessoa? Pessoa { get; set; }

    private Paciente() { }

    public Paciente(string convenio, string nomeCompleto, string cpf)
    : base(nomeCompleto, cpf)
    {
        Convenio = convenio;
    }
}