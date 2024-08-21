namespace ProofIdentity.Domain.Repositories;
public interface IMedicoWriteRepository
{
    Task<Guid> CreateAsync(Medico medico, string password);
    Task UpdateAsync(Medico medico);
    Task RemoveAsync(Medico medico);
}