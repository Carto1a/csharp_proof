using ProofIdentity.Domain;

namespace ProofIdentity.Application.Repositories;
public interface IBasicUserReadRepository
{
    Task<BasicUser?> GetById(Guid id);
    Task<List<BasicUser>> GetAll();
    Task<BasicUser?> FindByUsername(string username);
    Task<BasicUser?> FindByEmail(string email);
}