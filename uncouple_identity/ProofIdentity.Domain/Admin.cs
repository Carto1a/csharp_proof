namespace ProofIdentity.Domain;
public class Admin : Pessoa
{
    public string Info { get; set; }

    public Admin() { }

    public Admin(string info, string nomeCompleto, string cpf, string email)
    : base(nomeCompleto, cpf, email)
    {
        Info = info;
    }
}