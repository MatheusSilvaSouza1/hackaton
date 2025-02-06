namespace Domain.Services
{
    public interface IConsultaService
    {
        Task<bool> CriarConsultaAsync(ConsultaDTO consulta);
        Task<bool> SetarStatusConsultaAsync(int idConsulta, bool isAceita);
        Task<List<Consulta>> GetConsultasPorUsuarioAsync(int idUsuario);
        Task<bool> CancelarConsultaAsync(int idConsulta, string justificativa);
    }
}
