namespace ProofIdentity.Application.Excetions;
public class ApplicationLayerException : Exception
{
    public ApplicationLayerException(string message) : base(message)
    { }
}