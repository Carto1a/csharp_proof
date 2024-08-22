namespace ProofIdentity.Application.DTOs.Registers;
public record PessoaRegisterDto
{
    public required string NomeCompleto { get; init; }
    public required string CPF { get; init; }
    public required string Senha { get; init; }
}