namespace Domain.Repositories
{
    public interface IHorarioDisponivelRepository
    {
        Task<bool> AdicionarHorarioAsync(HorarioDisponivel horario);
        Task<List<HorarioDisponivel>> GetHorariosPorMedicoAsync(int idMedico);
        Task<HorarioDisponivel> GetHorarioDisponivel(int idHorario);
        Task<bool> ExisteHorarioParaMedicoAsync(int idMedico, DateTime data);
        Task UpdateAsync(HorarioDisponivel horario);
    }
}
