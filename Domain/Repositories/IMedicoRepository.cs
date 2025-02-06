namespace Domain.Repositories
{
    public interface IMedicoRepository
    {
        Task AddAsync(Medico loginDto);
        Task<List<Medico>> GetMedicosPorEspecialidade(string especialidade);        
    }
}
