using Microsoft.AspNetCore.Mvc;

using ProofIdentity.Application.DTOs.Registers;
using ProofIdentity.Application.UseCases.Registers;

namespace ProofIdentity.WebApi.Controllers;

public class RegisterController : ControllerBase
{
    [HttpPost("Paciente")]
    public Task<IActionResult> RegisterPaciente()
    {
        throw new NotImplementedException();
    }

    [HttpPost("Medico")]
    public Task<IActionResult> RegisterMedico()
    {
        throw new NotImplementedException();
    }

    [HttpPost("Administrador")]
    public async Task<IActionResult> RegisterAdmin(
        [FromServices] AdminRegisterUseCase useCase,
        [FromBody] AdminRegisterDto request)
    {
        var result = await useCase.Handler(request);
        return Ok(result);
    }
}