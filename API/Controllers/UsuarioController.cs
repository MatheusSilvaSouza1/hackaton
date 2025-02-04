using Application.Services;
using Domain;
using Domain.Repositories;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly IMedicoServices _medicoServices;
    private readonly IHorarioDisponivelService _horarioDisponivelService;
    private readonly IConsultaService _consultaService;

    public UsuarioController(IMedicoServices medicoServices, IHorarioDisponivelService horarioDisponivelService, IConsultaService consultaService)
    {
        _medicoServices = medicoServices;
        _horarioDisponivelService = horarioDisponivelService;
        _consultaService = consultaService;
    }

    [HttpGet("ConsultarMedicosPorEspecialidade")]
    public async Task<IActionResult> ConsultarMedicosPorEspecialidade(string? especialidade)
    {
        try
        {
            var result = await _medicoServices.GetMedicosPorEspecialidade(especialidade);

            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("CriarConsulta")]
    public async Task<IActionResult> CriarConsulta(Consulta consulta)
    {
        try
        {
            var sucesso = await _consultaService.CriarConsultaAsync(consulta);
            if (sucesso)
                return Ok("Consulta criada com sucesso.");
            else
                return BadRequest("Já existe uma consulta para o médico no mesmo horário.");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("horarios/{idMedico}")]
    public async Task<IActionResult> GetHorariosPorMedico(int idMedico)
    {
        try
        {
            var horarios = await _horarioDisponivelService.GetHorariosPorMedicoAsync(idMedico);
            if (horarios == null || horarios.Count == 0)
            {
                return NotFound("Nenhum horário encontrado para o médico.");
            }
            return Ok(horarios);
        }
        catch (Exception ex)
        {
            return BadRequest($"Ocorreu um erro: {ex.Message}");
        }
    }
}
