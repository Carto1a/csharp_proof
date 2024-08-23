using Microsoft.EntityFrameworkCore;

using ProofIdentity.Application.Repositories;
using ProofIdentity.Domain;
using ProofIdentity.Domain.Repositories;

namespace ProofIdentity.Infrastructure.Database.Repositories;
public class AgendamentoRepository : IAgendamentoReadRepository, IAgendamentoWriteRepository
{
    private readonly DataContext _context;
    public AgendamentoRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<Guid> AddAsync(Agendamento agendamento)
    {
        try
        {
            _context.Agendamentos.AddAsync(agendamento);
            return agendamento.Id;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public Task DeleteAsync(Agendamento agendamento)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Agendamento>> GetAllAsync()
    {
        try
        {
            var query = _context.Agendamentos;
            var result = await query.ToListAsync();

            return result;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public Task<Agendamento> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Agendamento agendamento)
    {
        throw new NotImplementedException();
    }
}