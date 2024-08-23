using Microsoft.AspNetCore.Mvc;
using ProofIdentity.Application.DTOs.Agendamentos;
using ProofIdentity.Application.Repositories;
using ProofIdentity.Application.UseCases.Agendamentos;

namespace ProofIdentity.WebApi.Controllers;
[ApiController]
[Route("api/[controller]")]
public class AgendamentoController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Add(
        [FromServices] AgendamentoCreateUseCase useCase,
        [FromBody] AgendamentoCreateDto request)
    {
        var result = await useCase.Handler(request);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(
        [FromServices] IAgendamentoReadRepository repository,
        Guid id)
    {
        var result = await repository.GetByIdAsync(id);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(
        [FromServices] IAgendamentoReadRepository repository)
    {
        var result = await repository.GetAllAsync();
        return Ok(result);
    }
}