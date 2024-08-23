using Microsoft.AspNetCore.Mvc;
using ProofIdentity.Application.Repositories;

namespace ProofIdentity.WebApi.Controllers;
[ApiController]
[Route("api/[controller]")]
public class AdminController : ControllerBase
{
    [HttpGet("{cpf}")]
    public async Task<IActionResult> GetByCpf(
        [FromServices] IAdminReadRepository repository,
        string cpf)
    {
        var result = await repository.GetByCpfDto(cpf);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(
        [FromServices] IAdminReadRepository repository)
    {
        var result = await repository.GetAllDto();
        return Ok(result);
    }
}