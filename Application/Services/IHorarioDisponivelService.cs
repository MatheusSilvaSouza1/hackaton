namespace Domain.Services
{
    public interface IHorarioDisponivelService
    {
        Task<bool> AdicionarHorarioAsync(HorarioDisponivel horario);
        Task<List<HorarioDisponivel>> GetHorariosPorMedicoAsync(int idMedico);
        Task<bool> EditarHorarioAsync(int id, HorarioDisponivelDto horario);
    }
}
