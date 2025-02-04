using Domain;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    public class HorarioDisponivelRepository : IHorarioDisponivelRepository
    {
        private readonly Context _context;

        public HorarioDisponivelRepository(Context context)
        {
            _context = context;
        }

        public async Task<bool> AdicionarHorarioAsync(HorarioDisponivel horario)
        {
            
            bool existe = await _context.HorarioDisponiveis
                .AnyAsync(h => h.IdMedico == horario.IdMedico
                            && h.DataHoraConsulta == horario.DataHoraConsulta);

            if (existe)
                return false; 
            
            await _context.HorarioDisponiveis.AddAsync(horario);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<HorarioDisponivel>> GetHorariosPorMedicoAsync(int idMedico)
        {
            return await _context.HorarioDisponiveis
                .Where(h => h.IdMedico == idMedico)
                .ToListAsync();
        }
    }
}
