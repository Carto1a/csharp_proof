namespace ProofIdentity.Domain.Repositories;
public interface IAdminWriteRepository
{
    Task<Guid> CreateAsync(Admin admin, string password);
    Task UpdateAsync(Admin admin);
    Task RemoveAsync(Admin admin);
}