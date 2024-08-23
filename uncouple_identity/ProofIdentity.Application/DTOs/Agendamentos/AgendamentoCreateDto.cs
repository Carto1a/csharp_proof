namespace ProofIdentity.Application.DTOs.Agendamentos;
public record class AgendamentoCreateDto
{
    public required string Data { get; set; }
    public required DateTime DataAgendamento { get; set; }
    public required string AdminCpf { get; set; }
}