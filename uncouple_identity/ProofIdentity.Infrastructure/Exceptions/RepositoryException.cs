using System.Collections;

namespace ProofIdentity.Infrastructure.Exceptions;
public class RepositoryException : Exception
{
    public IEnumerable Errors { get; } = new List<string>();
    public RepositoryException(string message) : base(message)
    { }
    public RepositoryException(IEnumerable errors)
    {
        Errors = errors;
    }
}