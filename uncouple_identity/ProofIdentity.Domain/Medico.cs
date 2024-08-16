namespace ProofIdentity.Domain;
public class Medico : Pessoa
{
    public string Crm { get; set; }
    public string UfCrm { get; set; }
    public Pessoa? Pessoa { get; set; }

    private Medico() { }

    public Medico(string crm, string ufCrm, string nomeCompleto, string cpf)
    : base(nomeCompleto, cpf)
    {
        Crm = crm;
        UfCrm = ufCrm;
    }
}