namespace ProofIdentity.Domain;
public interface ILoginUser
{
    public string Email { get; set; }
    public string PasswordHash { get; set; }
}