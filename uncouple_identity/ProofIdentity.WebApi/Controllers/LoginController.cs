using Microsoft.AspNetCore.Mvc;

namespace ProofIdentity.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LoginController : ControllerBase
{
    [HttpPost]
    public Task<IActionResult> Login()
    {
        throw new NotImplementedException();
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