using Domain;
using Domain.Repositories;
using Domain.Services;

namespace Infra.Services
{
    public class HorarioDisponivelService : IHorarioDisponivelService
    {
        private readonly IHorarioDisponivelRepository _horarioDisponivelRepository;

        
        public HorarioDisponivelService(IHorarioDisponivelRepository horarioDisponivelRepository)
        {
            _horarioDisponivelRepository = horarioDisponivelRepository;
        }

        
        public async Task<bool> AdicionarHorarioAsync(HorarioDisponivel horario)
        {
            return await _horarioDisponivelRepository.AdicionarHorarioAsync(horario);
        }

        
        public async Task<List<HorarioDisponivel>> GetHorariosPorMedicoAsync(int idMedico)
        {
            return await _horarioDisponivelRepository.GetHorariosPorMedicoAsync(idMedico);
        }
        public async Task<bool> EditarHorarioAsync(int id, HorarioDisponivelDto horario)
        {
            var horarioExistente = await _horarioDisponivelRepository.GetHorarioDisponivel(id);

            if (horarioExistente == null) return false;
                        
            var existeHorario = await _horarioDisponivelRepository.ExisteHorarioParaMedicoAsync(horarioExistente.IdMedico, horario.DataHoraConsulta);

            if (existeHorario) return false;

            horarioExistente.DataHoraConsulta = horario.DataHoraConsulta;
            horarioExistente.ValorConsulta = horario.ValorConsulta;
            

            await _horarioDisponivelRepository.UpdateAsync(horarioExistente);
            return true;
        }
    }
}
