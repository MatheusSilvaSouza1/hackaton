namespace Domain.Repositories
{
    public interface IMedicoRepository
    {                
        Task<List<Medico>> GetMedicosPorEspecialidade(string especialidade);
    }
}
