namespace Domain.Repositories
{
    public interface IConsultaRepository
    {
        Task<Consulta> GetConsultaByHorarioAsync(int idMedico, int idHorarioDisponivel);
        Task AddAsync(Consulta consulta);
    }
}
