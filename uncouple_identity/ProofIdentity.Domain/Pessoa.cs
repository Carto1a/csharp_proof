namespace ProofIdentity.Domain;
public class Pessoa : Entity
{
    public string NomeCompleto { get; set; }
    public string CPF { get; set; }

    private Pessoa() { }

    public Pessoa(string nomeCompleto, string cpf)
    {
        NomeCompleto = nomeCompleto;
        CPF = cpf;
    }
}