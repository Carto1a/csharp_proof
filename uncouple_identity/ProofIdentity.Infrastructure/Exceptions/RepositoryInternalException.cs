namespace ProofIdentity.Infrastructure.Exceptions;
public class RepositoryInternalException : Exception
{
    public RepositoryInternalException(string message) : base(message)
    { }
}