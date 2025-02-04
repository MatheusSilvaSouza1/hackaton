using Domain;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    public class MedicoRepository(Context context) : IMedicoRepository
    {
        private readonly Context _context = context;

        public async Task<List<Medico>> GetMedicosPorEspecialidade(string especialidade)
        {
            if (string.IsNullOrWhiteSpace(especialidade))
                return _context.Medicos.ToList();

            return await _context.Medicos
                .Where(m => m.Especialidade == especialidade)
                .ToListAsync();
        }
    }
}
