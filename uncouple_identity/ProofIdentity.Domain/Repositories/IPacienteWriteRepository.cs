namespace ProofIdentity.Domain.Repositories;
public interface IPacienteWriteRepository
{
    Task UpdateAsync(Paciente paciente);
    Task RemoveAsync(Paciente paciente);
}