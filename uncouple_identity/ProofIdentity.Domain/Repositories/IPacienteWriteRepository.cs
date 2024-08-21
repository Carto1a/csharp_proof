namespace ProofIdentity.Domain.Repositories;
public interface IPacienteWriteRepository
{
    Task<Guid> CreateAsync(Paciente paciente, string password);
    Task UpdateAsync(Paciente paciente);
    Task RemoveAsync(Paciente paciente);
}