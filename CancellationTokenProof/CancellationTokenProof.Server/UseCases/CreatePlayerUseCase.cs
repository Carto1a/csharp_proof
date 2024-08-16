using CancellationTokenProof.Server.Repositories;

namespace CancellationTokenProof.Server.UseCases;
public class CreatePlayerUseCase
{
    private readonly PlayerRepository _repository;
    public CreatePlayerUseCase(PlayerRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> Handler(string name)
    {
        return await Handler(name, CancellationToken.None);
    }

    public async Task<Guid> Handler(string name, CancellationToken token)
    {
        var playerExists = await _repository.GetByName(name);
        if (playerExists is not null)
        {
            throw new Exception("Player already exists");
        }

        Player player = new(name);
        player.Validate();

        Guid id = await _repository.Create(player);

        return id;
    }
}
