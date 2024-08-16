using CancellationTokenProof.Server.Repositories;

namespace CancellationTokenProof.Server;
public class DeletePlayerUseCase
{
    private readonly PlayerRepository _repository;
    public DeletePlayerUseCase(PlayerRepository repository)
    {
        _repository = repository;
    }

    public async Task Handler(Guid playerId, CancellationToken cancellationToken)
    {
        var player = await _repository.GetById(playerId, cancellationToken);
        if (player is null)
        {
            throw new Exception("Player not found");
        }

        await _repository.Delete(player, cancellationToken);
    }
}
