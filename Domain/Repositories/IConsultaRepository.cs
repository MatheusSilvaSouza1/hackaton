namespace Domain.Repositories
{
    public interface IConsultaRepository
    {
        Task<Consulta> GetConsultaByHorarioAsync(int idMedico, int idHorarioDisponivel);
        Task AddAsync(Consulta consulta);
        Task<Consulta?> GetByIdAsync(int idConsulta);
        Task UpdateAsync(Consulta consulta);
        Task<List<Consulta>> GetConsultasPorUsuarioAsync(int idUsuario);
    }
}
