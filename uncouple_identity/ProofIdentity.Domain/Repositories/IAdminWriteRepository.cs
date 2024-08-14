namespace ProofIdentity.Domain.Repositories;
public interface IAdminWriteRepository
{
    Task UpdateAsync(Admin admin);
    Task RemoveAsync(Admin admin);
}