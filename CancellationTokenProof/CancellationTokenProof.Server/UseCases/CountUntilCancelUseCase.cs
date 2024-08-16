using CancellationTokenProof.Server.Repositories;

namespace CancellationTokenProof.Server.UseCases;
public class CountUntilCancelUseCase
{
    private readonly ILogger<CountUntilCancelUseCase> _logger;
    private readonly PlayerRepository _repository;

    public CountUntilCancelUseCase(ILogger<CountUntilCancelUseCase> logger, PlayerRepository repository)
    {
        _logger = logger;
        _repository = repository;
    }

    public async Task<int> Handler(Guid playerId, string name, int limit)
    {
        return await Handler(playerId, name, limit, CancellationToken.None);
    }

    public async Task<int> Handler(Guid playerId, string name, int limit, CancellationToken cancellationToken)
    {
        var player = await _repository.GetById(playerId);
        if (player is null)
        {
            throw new Exception("Player not found");
        }

        int count = 0;

        while (true)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                await AddScore(player, limit, count);
                break;
            }

            count++;
            if (count >= limit)
                break;

            try
            {
                await Task.Delay(1, cancellationToken);
            }
            catch (TaskCanceledException)
            {
                await AddScore(player, limit, count);
                break;
            }
        }

        return count;
    }

    private async Task AddScore(Player player, int limit, int count)
    {
        player.AddScore(limit, count);
        await _repository.Update(player);
    }
}
