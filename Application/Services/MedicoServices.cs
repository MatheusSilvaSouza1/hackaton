using Domain;
using Domain.Repositories;

namespace Application.Services;

public class MedicoServices(IMedicoRepository medicoRepository) : IMedicoServices
{
    private readonly IMedicoRepository _medicosRepository = medicoRepository;

    public async Task CreateMedico(MedicoDto loginDto)
    {
        await _medicosRepository.AddAsync(new Medico
        {
            Crm = loginDto.Crm,
            Especialidade = loginDto.Especialidade,
            Senha = loginDto.Senha,
        });
    }

    public async Task<List<Medico>> GetMedicosPorEspecialidade(string especialidade)
    {
        return await _medicosRepository.GetMedicosPorEspecialidade(especialidade);        
    }

}