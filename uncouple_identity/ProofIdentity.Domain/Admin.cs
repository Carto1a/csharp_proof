namespace ProofIdentity.Domain;
public class Admin : Entity
{
    public string Info { get; set; }
    public Pessoa Pessoa { get; set; }

    private Admin() { }

    public Admin(string info, string nomeCompleto, string cpf)
    {
        Info = info;
        Pessoa = new Pessoa(nomeCompleto, cpf);
    }
}