using Microsoft.AspNetCore.Mvc;

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
    public Task<IActionResult> RegisterAdmin()
    {
        throw new NotImplementedException();
    }
}