namespace ProofIdentity.Domain;
public class BasicUser : Entity
{
    public string UserName { get; set; }
    public string NameCompleto { get; set; }
    public string Email { get; set; }
    public DateOnly DataNascimento { get; set; }
    public string Cpf { get; set; }

    public BasicUser() { }

    public BasicUser(
        string userName,
        string nameCompleto,
        string email,
        DateOnly dataNascimento,
        string cpf)
    {
        UserName = userName;
        NameCompleto = nameCompleto;
        Email = email;
        DataNascimento = dataNascimento;
        Cpf = cpf;
    }

    public bool CheckUniquess(BasicUser user)
    {
        return user.UserName == UserName
            || user.Email == Email
            || user.Cpf == Cpf;
    }
}