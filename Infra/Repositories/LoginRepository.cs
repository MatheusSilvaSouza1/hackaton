using Domain;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    public class LoginRepository(Context context) : ILoginRepository
    {
        private readonly Context _context = context;

        public async Task AddAsync(Login login)
        {
            await _context.Login.AddAsync(login);
            await _context.SaveChangesAsync();
        }

        public async Task<Login> GetUserByUsernameAndPassword(string username, string password)
        {
            return await _context.Login
                .Where(property => property.Password == password && property.Username == username)
                .FirstAsync();
        }
    }
}
