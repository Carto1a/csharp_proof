namespace ProofIdentity.Domain.Repositories;
public interface IBasicUserWriteRepository
{
    Task<Guid> CreateAsync(BasicUser user, string password);
    void Update(BasicUser user);
    Task DeleteAsync(BasicUser user);
}