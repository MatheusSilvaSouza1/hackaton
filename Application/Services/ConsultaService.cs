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
    }
}
