using System.Collections;

namespace ProofIdentity.Application.Excetions;
public class ApplicationLayerException : Exception
{
    public IEnumerable Errors { get; set; }

    public ApplicationLayerException(string message) : base(message)
    { }
    public ApplicationLayerException(string message, Exception innerException) : base(message, innerException)
    { }
    public ApplicationLayerException(string message, IEnumerable errors, Exception innerException) : base(message, innerException)
    { }
    public ApplicationLayerException(string message, IEnumerable errors) : base(message)
    {
        Errors = errors;
    }
}