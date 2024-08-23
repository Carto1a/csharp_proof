namespace ProofIdentity.Application.DTOs;
public record class AdminDto
{
    public required Guid Id { get; set; }
    public required string Nome { get; set; }
    public required string Cpf { get; set; }
}