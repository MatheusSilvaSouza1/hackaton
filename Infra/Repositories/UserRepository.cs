using Domain;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    public class UserRepository(Context context) : IUserRepository
    {
        private readonly Context _context = context;
        public async Task AddAsync(Usuario paciente)
        {
            await _context.Usuarios.AddAsync(paciente);
            await _context.SaveChangesAsync();
        }

        public async Task<Usuario> GetUserByUsernameAndPassword(string username, string password)
        {
            return await _context.Usuarios.Where(property => property.Email == username && property.Password == password).FirstAsync();
        }
    }
}
