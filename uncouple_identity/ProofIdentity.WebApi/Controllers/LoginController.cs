using Microsoft.AspNetCore.Mvc;

using ProofIdentity.Application.DTOs.Logins;
using ProofIdentity.Application.UseCases.Logins;

namespace ProofIdentity.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LoginController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Login(
        [FromServices] AdminLoginUseCase _useCase,
        [FromBody] LoginDto loginDto)
    {
        var result = await _useCase.Handler(loginDto);
        return Ok(result);
    }

    [HttpPost("Administrador")]
    public Task<IActionResult> LoginAdmin()
    {
        throw new NotImplementedException();
    }

    [HttpPost("Paciente")]
    public Task<IActionResult> LoginPeciente()
    {
        throw new NotImplementedException();
    }

    [HttpPost("Medico")]
    public Task<IActionResult> LoginMedico()
    {
        throw new NotImplementedException();
    }
}