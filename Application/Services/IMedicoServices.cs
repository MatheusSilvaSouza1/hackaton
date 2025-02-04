using Domain;

namespace Application.Services;

public interface IMedicoServices
{
    Task<List<Medico>> GetMedicosPorEspecialidade(string especialidade);
}