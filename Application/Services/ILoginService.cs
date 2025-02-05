using Domain;

namespace Application.Services
{
    public interface ILoginService
    {
        Task<string> GetTokenMedico(LoginDto loginDto);
        Task CreateMedico(LoginDto loginDto);
        Task CreatePaciente(LoginDto loginDto);
    }
}
