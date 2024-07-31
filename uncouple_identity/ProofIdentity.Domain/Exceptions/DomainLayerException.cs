namespace ProofIdentity.Domain.Exceptions;
public class DomainLayerException : Exception
{
    public DomainLayerException(string message) : base(message)
    { }
}