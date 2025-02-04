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
        public async Task<bool> ExisteHorarioParaMedicoAsync(int idMedico, DateTime data)
        {
            return await _context.HorarioDisponiveis
                .AnyAsync(h => h.IdMedico == idMedico && h.DataHoraConsulta == data);
        }

        public async Task UpdateAsync(HorarioDisponivel horario)
        {
            _context.HorarioDisponiveis.Update(horario);
            await _context.SaveChangesAsync();
        }
        public async Task<HorarioDisponivel> GetHorarioDisponivel(int idHorario)
        {
            return _context.HorarioDisponiveis
                .Where(h => h.Id == idHorario).FirstOrDefault();
        }
    }
}
