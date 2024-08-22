namespace ProofIdentity.Application.DTOs.Registers;
public record AdminRegisterDto : PessoaRegisterDto
{
    public required string Info { get; init; }
}