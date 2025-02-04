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
    }
}
