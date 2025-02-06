
namespace Domain.Repositories
{
    public interface IUserRepository
    {
        Task AddAsync(Usuario loginDto);
        Task<Usuario> GetUserByUsernameAndPassword(string username, string password);
    }
}
