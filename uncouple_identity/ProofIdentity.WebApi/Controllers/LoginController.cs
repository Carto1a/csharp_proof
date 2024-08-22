using Microsoft.AspNetCore.Mvc;

using ProofIdentity.Application.DTOs.Logins;
using ProofIdentity.Application.UseCases.Logins;
using ProofIdentity.Domain;

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
        string token = loginDto.Role switch
        {
            Roles.Administrador => await _useCase.Handler(loginDto),
            Roles.Paciente => await _useCase.Handler(loginDto),
            Roles.Medico => await _useCase.Handler(loginDto),
            _ => throw new NotImplementedException(),
        };
        return Ok(token);
    }

    [HttpPost("Administrador")]
    public async Task<IActionResult> LoginAdmin(
        [FromServices] AdminLoginUseCase _useCase,
        [FromBody] LoginDto loginDto)
    {
        var token = await _useCase.Handler(loginDto);
        return Ok(token);
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