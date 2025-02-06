using Domain;

namespace Application.Services;

public interface IMedicoServices
{
    Task CreateMedico(MedicoDto loginDto);
    Task<List<Medico>> GetMedicosPorEspecialidade(string especialidade);
}