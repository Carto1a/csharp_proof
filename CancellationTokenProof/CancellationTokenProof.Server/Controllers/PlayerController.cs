using CancellationTokenProof.Server.Repositories;
using CancellationTokenProof.Server.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace CancellationTokenProof.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class PlayerController : ControllerBase
{
    private readonly PlayerRepository _repository;
    public PlayerController(PlayerRepository repository)
    {
        _repository = repository;
    }

    [HttpPost("Create")]
    public async Task<IActionResult> Create(
        [FromServices] CreatePlayerUseCase useCase,
        [FromQuery] string name,
        CancellationToken token)
    {
        Guid id = await useCase.Handler(name, token);
        return Ok(id);
    }

    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete(
        [FromServices] DeletePlayerUseCase useCase,
        [FromQuery] Guid id,
        CancellationToken token)
    {
        await useCase.Handler(id, token);
        return Ok();
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll(CancellationToken token)
    {
        List<Player> players = await _repository.GetAll(token);
        return Ok(players);
    }

    [HttpGet("GetById")]
    public async Task<IActionResult> GetById(
        [FromQuery] Guid id,
        CancellationToken token)
    {
        Player? player = await _repository.GetById(id, token);
        if (player is null)
        {
            return NotFound();
        }

        return Ok(player);
    }
}
