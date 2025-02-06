using Domain;
using Domain.Repositories;

namespace Application.Services;

public class MedicoServices(IMedicoRepository medicoRepository) : IMedicoServices
{
    private readonly IMedicoRepository _medicosRepository = medicoRepository;

    public async Task CreateMedico(MedicoDto medicoDto)
    {
        await _medicosRepository.AddAsync(new Medico
        {
            Crm = medicoDto.Crm,
            Especialidade = medicoDto.Especialidade,
            Senha = medicoDto.Senha,
            Nome = medicoDto.Nome
        });
    }

    public async Task<List<Medico>> GetMedicosPorEspecialidade(string especialidade)
    {
        return await _medicosRepository.GetMedicosPorEspecialidade(especialidade);        
    }

}