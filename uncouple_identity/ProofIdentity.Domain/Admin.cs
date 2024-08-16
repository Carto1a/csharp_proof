namespace ProofIdentity.Domain;
public class Admin : Pessoa
{
    public string Info { get; set; }

    private Admin() { }

    public Admin(string info, string nomeCompleto, string cpf)
    : base(nomeCompleto, cpf)
    {
        Info = info;
    }
}