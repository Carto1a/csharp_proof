using Microsoft.EntityFrameworkCore.Storage;
using ProofIdentity.Application.Repositories;
using ProofIdentity.Infrastructure.Exceptions;

namespace ProofIdentity.Infrastructure.Database.Repositories;
public class UnitOfWork : IUnitOfWork
{
    private readonly DataContext _context;
    private IDbContextTransaction? _transaction;
    public UnitOfWork(DataContext context)
    {
        _context = context;
    }

    public async Task BeginTransactionAsync()
    {
        _transaction = await _context.Database.BeginTransactionAsync();
    }

    public async Task CommitAsync()
    {
        IsTransactionStarted();

        await SaveChangesAsync();
        await _transaction.CommitAsync();

        return;
    }

    public Task RollbackAsync()
    {
        IsTransactionStarted();

        return _transaction.RollbackAsync();
    }

    public Task SaveChangesAsync()
    {
        return _context.SaveChangesAsync();
    }

    private void IsTransactionStarted()
    {
        if (_transaction == null)
            throw new RepositoryInternalException("Transaction not started");
    }
}