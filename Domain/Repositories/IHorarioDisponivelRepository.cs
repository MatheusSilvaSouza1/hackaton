namespace Domain.Repositories
{
    public interface IHorarioDisponivelRepository
    {
        Task<bool> AdicionarHorarioAsync(HorarioDisponivel horario);
        Task<List<HorarioDisponivel>> GetHorariosPorMedicoAsync(int idMedico);
    }
}
