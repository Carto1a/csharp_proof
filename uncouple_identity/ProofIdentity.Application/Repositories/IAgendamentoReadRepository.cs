using ProofIdentity.Domain;

namespace ProofIdentity.Application.Repositories;
public interface IAgendamentoReadRepository
{
    Task<Agendamento> GetByIdAsync(Guid id);
    Task<IEnumerable<Agendamento>> GetAllAsync();
}