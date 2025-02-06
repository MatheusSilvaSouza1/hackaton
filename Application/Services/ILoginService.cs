using Domain;

namespace Application.Services
{
    public interface ILoginService
    {
        Task<string> GetTokenMedico(LoginDto loginDto);
        Task<string> GetTokenPaciente(LoginDto loginDto);
    }
}
