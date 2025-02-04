using Application.Services;
using Domain;
using Domain.Repositories;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class MedicoController(IMedicoServices medicoServices, IHorarioDisponivelService horarioDisponivelService) : ControllerBase
{
    private readonly IMedicoServices _medicoServices = medicoServices;
    private readonly IHorarioDisponivelService _horarioDisponivelService = horarioDisponivelService;
        
    [HttpPost("AdicionarHorario")]
    public async Task<IActionResult> AdicionarHorario(HorarioDisponivel horario)
    {
        try
        {
            var result = await _horarioDisponivelService.AdicionarHorarioAsync(horario);
            if (result)
                return Ok(result);
            else return BadRequest("Horário já cadastrado para o medico");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
