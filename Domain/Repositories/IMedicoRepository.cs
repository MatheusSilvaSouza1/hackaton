namespace Domain.Repositories
{
    public interface IMedicoRepository
    {
        Task AddAsync(Medico loginDto);
        Task<Medico> GetMedicoByUsernameAndPassword(string username, string password);
        Task<List<Medico>> GetMedicosPorEspecialidade(string especialidade);        
    }
}
