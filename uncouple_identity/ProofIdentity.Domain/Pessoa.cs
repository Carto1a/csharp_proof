namespace ProofIdentity.Domain;
public partial class Pessoa : Entity, ILoginUser
{
    public string NomeCompleto { get; set; }
    public string CPF { get; set; }
    public Guid SecurityStamp { get; set; }
    public string PasswordHash { get; set; }
    public string Email { get; set; }

    public Pessoa() { }

    public Pessoa(string nomeCompleto, string cpf)
    {
        NomeCompleto = nomeCompleto;
        CPF = cpf;
        SecurityStamp = Guid.NewGuid();
    }

}