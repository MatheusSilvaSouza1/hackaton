namespace Domain.Services
{
    public interface IConsultaService
    {
        Task<bool> CriarConsultaAsync(Consulta consulta);
    }
}
