namespace ProofIdentity.Domain.Repositories;
public interface IAgendamentoWriteRepository
{
    Task<Guid> AddAsync(Agendamento agendamento);
    Task UpdateAsync(Agendamento agendamento);
    Task DeleteAsync(Agendamento agendamento);
}