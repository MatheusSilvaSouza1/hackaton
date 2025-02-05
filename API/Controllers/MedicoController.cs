using Application.Services;
using Domain;
using Domain.Repositories;
using Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class MedicoController(IMedicoServices medicoServices, IHorarioDisponivelService horarioDisponivelService, IConsultaService consultaService) : ControllerBase
{
    private readonly IMedicoServices _medicoServices = medicoServices;
    private readonly IHorarioDisponivelService _horarioDisponivelService = horarioDisponivelService;
    private readonly IConsultaService _consultaService = consultaService;

    [HttpPost("AdicionarHorario")]
    [Authorize(Roles = PermissionSystem.Doctor)]
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
    [HttpPut("EditarHorario/{id}")]
    [Authorize(Roles = PermissionSystem.Doctor)]
    public async Task<IActionResult> EditarHorario(int id, [FromBody] HorarioDisponivelDto horario)
    {
        try
        {
            var result = await _horarioDisponivelService.EditarHorarioAsync(id, horario);
            if (result)
                return Ok("Horário atualizado com sucesso.");
            else
                return BadRequest("Horário não encontrado ou já existente.");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpPut("SetarStatusConsulta/{idConsulta}")]
    [Authorize(Roles = PermissionSystem.Doctor)]
    public async Task<IActionResult> SetarStatusConsulta(int idConsulta, [FromQuery] bool isAceita)
    {
        try
        {
            var resultado = await _consultaService.SetarStatusConsultaAsync(idConsulta, isAceita);
            if (resultado)
                return Ok("Status da consulta atualizado com sucesso.");
            else
                return BadRequest("Consulta não encontrada ou Já existe uma consulta para o médico no mesmo horário.");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
