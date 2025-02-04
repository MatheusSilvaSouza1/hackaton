using Domain.Repositories;
using Domain;
using Domain.Services;

namespace Application.Services
{
    public class ConsultaService : IConsultaService
    {
        private readonly IConsultaRepository _consultaRepository;
        private readonly IHorarioDisponivelRepository _horarioDisponivelRepository;

        public ConsultaService(IConsultaRepository consultaRepository, IHorarioDisponivelRepository horarioDisponivelRepository)
        {
            _consultaRepository = consultaRepository;
            _horarioDisponivelRepository = horarioDisponivelRepository;
        }

        public async Task<bool> CriarConsultaAsync(Consulta consulta)
        {
            
            var horariosDisponiveis = await _horarioDisponivelRepository.GetHorariosPorMedicoAsync(consulta.IdMedico);
            var horarioConsulta = horariosDisponiveis.FirstOrDefault(h => h.Id == consulta.IdHorarioDisponivel);

            if (horarioConsulta == null)
                return false;

            
            var consultaExistente = await _consultaRepository.GetConsultaByHorarioAsync(consulta.IdMedico, consulta.IdHorarioDisponivel);
            if (consultaExistente != null)
                return false; 

            
            await _consultaRepository.AddAsync(consulta);
            return true;
        }
        public async Task<bool> SetarStatusConsultaAsync(int idConsulta, bool isAceita)
        {
            var consulta = await _consultaRepository.GetByIdAsync(idConsulta);
            
            if (consulta == null) return false;
            if (isAceita == true && consulta.IsAceita == false)
            {
                var consultaExistente = await _consultaRepository.GetConsultaByHorarioAsync(consulta.IdMedico, consulta.IdHorarioDisponivel);
                if(consultaExistente != null) return false;
            };

            consulta.IsAceita = isAceita;
            await _consultaRepository.UpdateAsync(consulta);
            return true;
        }
        public async Task<List<Consulta>> GetConsultasPorUsuarioAsync(int idUsuario)
        {
            return await _consultaRepository.GetConsultasPorUsuarioAsync(idUsuario);
        }
        public async Task<bool> CancelarConsultaAsync(int idConsulta, string justificativa)
        {
            var consulta = await _consultaRepository.GetByIdAsync(idConsulta);
            if (consulta == null || string.IsNullOrEmpty(justificativa)) return false;

            consulta.IsCancelada = true;
            consulta.Justificativa = justificativa;

            await _consultaRepository.UpdateAsync(consulta);
            return true;
        }
    }
}
