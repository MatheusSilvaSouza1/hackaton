using Domain;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    public class MedicoRepository(Context context) : IMedicoRepository
    {
        private readonly Context _context = context;

        public async Task AddAsync(Medico medico)
        {
            await _context.Medicos.AddAsync(medico);
            await _context.SaveChangesAsync();
        }

        public async Task<Medico> GetMedicoByUsernameAndPassword(string username, string password)
        {
            return await _context.Medicos.Where(property => property.Crm == username && property.Senha == password).FirstAsync();
        }

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
