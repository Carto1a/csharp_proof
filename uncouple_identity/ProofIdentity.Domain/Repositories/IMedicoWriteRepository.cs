namespace ProofIdentity.Domain.Repositories;
public interface IMedicoWriteRepository
{
    Task UpdateAsync(Medico medico);
    Task RemoveAsync(Medico medico);
}