namespace ProofIdentity.Application.Repositories;
public interface IUnitOfWork
{
    Task CommitAsync();
    Task RollbackAsync();
    Task SaveChangesAsync();
    Task BeginTransactionAsync();
}