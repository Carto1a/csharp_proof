using CancellationTokenProof.Server.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace CancellationTokenProof.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class CountController : ControllerBase
{
    private readonly ILogger<CountController> _logger;

    public CountController(ILogger<CountController> logger)
    {
        _logger = logger;
    }

    [HttpGet("count")]
    public async Task<IActionResult> Count(
        [FromServices] CountUntilCancelUseCase useCase,
        [FromQuery] string name, [FromQuery] int limit, [FromQuery] Guid playerId,
        CancellationToken token)
    {
        int count = await useCase.Handler(playerId, name, limit, token);

        if (count >= limit)
        {
            return Ok("not canceled");
        }

        return Ok();
    }
}
