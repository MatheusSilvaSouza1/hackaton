
namespace Domain.Repositories
{
    public interface ILoginRepository
    {
        Task AddAsync(Login consulta);
        Task<Login> GetUserByUsernameAndPassword(string username, string password);
    }
}
