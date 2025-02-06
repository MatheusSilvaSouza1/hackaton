using Application.Services;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
[AllowAnonymous]
public class LoginController(ILoginService loginService) : ControllerBase
{
    private readonly ILoginService _loginService = loginService;

    [HttpPost("Token")]
    [Produces("application/json")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> GetToken([FromBody] LoginDto loginDto)
    {
        try
        {
            var tokenGenerated = loginDto.TypeAccess == TypeAccess.User ?
                await _loginService.GetTokenPaciente(loginDto) :
                await _loginService.GetTokenMedico(loginDto);

            return string.IsNullOrEmpty(tokenGenerated) ? Unauthorized() : Ok(tokenGenerated);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
