using Microsoft.AspNetCore.Mvc;

using ProofIdentity.Application.DTOs;
using ProofIdentity.Application.Repositories;
using ProofIdentity.Application.UseCases.BasicUser;

namespace ProofIdentity.WebApi.Controllers;
[ApiController]
[Route("api/[controller]")]
public class BasicUserController : ControllerBase
{
    [HttpPost("Register")]
    public async Task<IActionResult> Register(
        [FromServices] BasicUserRegisterUseCase service,
        [FromBody] RegisterBasicUserDto request)
    {
        Guid id = await service.Handler(request);
        return Ok(id);
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login(
        [FromServices] BasicUserLoginUseCase service,
        [FromBody] LoginBasicUserDto request)
    {
        var token = await service.Handler(request);
        return Ok(token);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(
        [FromServices] IBasicUserReadRepository repo)
    {
        var users = await repo.GetAll();
        return Ok(users);
    }
}