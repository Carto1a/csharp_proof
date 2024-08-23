namespace ProofIdentity.Domain;
public partial class Pessoa : Entity
{
    public string NomeCompleto { get; set; }

    public string CPF { get; set; }
    public string Email { get; set; }
    public bool LockoutEnabled { get; set; }
    public string PasswordHash { get; set; }
    public Guid SecurityStamp { get; set; }

    public Pessoa() { }

    public Pessoa(string nomeCompleto, string cpf, string email)
    {
        NomeCompleto = nomeCompleto;
        CPF = cpf;
        Email = email;
        LockoutEnabled = false;
        SecurityStamp = Guid.NewGuid();
    }
}