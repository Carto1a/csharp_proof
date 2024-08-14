namespace ProofIdentity.Domain;
public class Medico : Entity
{
    public string Crm { get; set; }
    public string UfCrm { get; set; }
    public Pessoa Pessoa { get; set; }

    private Medico() { }

    public Medico(string crm, string ufCrm, string nomeCompleto, string cpf)
    {
        Crm = crm;
        UfCrm = ufCrm;
        Pessoa = new Pessoa(nomeCompleto, cpf);
    }
}