using Microsoft.EntityFrameworkCore;

namespace CancellationTokenProof.Server.Repositories;
public class PlayerRepository
{
    private readonly DataContext _context;
    public PlayerRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<Guid> Create(Player player, CancellationToken cancellationToken = default)
    {
        _ = await _context.Players.AddAsync(player, cancellationToken);
        _ = await _context.SaveChangesAsync(cancellationToken);
        return player.Id;
    }

    public async Task<Player?> GetById(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Players
            .Include(p => p.Scores)
            .Include(p => p.HighScore)
            .Include(p => p.LastScore)
            .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
    }

    public async Task<Player?> GetByName(string name, CancellationToken cancellationToken = default)
    {
        return await _context.Players
            .Include(p => p.Scores)
            .Include(p => p.HighScore)
            .Include(p => p.LastScore)
            .FirstOrDefaultAsync(p => p.Name == name, cancellationToken);
    }

    public async Task<List<Player>> GetAll(CancellationToken cancellationToken = default)
    {
        return await _context.Players
            .Include(p => p.Scores)
            .Include(p => p.HighScore)
            .Include(p => p.LastScore)
            .ToListAsync(cancellationToken);
    }

    public async Task Update(Player player, CancellationToken cancellationToken = default)
    {
        _ = _context.Players.Update(player);
        _ = await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task Delete(Player player, CancellationToken cancellationToken = default)
    {
        _ = _context.Players.Remove(player);
        _ = await _context.SaveChangesAsync(cancellationToken);
    }
}
