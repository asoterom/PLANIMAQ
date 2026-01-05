using Planimaq.backend.Repositories.Interfaces;
using Planimaq.backend.UnitsOfWork.Interfaces;
using Planimaq.Shared.DTOs;
using Planimaq.Shared.Entities;
using Planimaq.Shared.Responses;

namespace Planimaq.backend.UnitsOfWork.Implementations;

public class EmpresasUnitOfWork : GenericUnitOfWork<Empresa>, IEmpresasUnitOfWork
{
    private readonly IEmpresasRepository _empresasRepository;

    public EmpresasUnitOfWork(IGenericRepository<Empresa> repository,
        IEmpresasRepository empresasRepository) : base(repository)
    {
        _empresasRepository = empresasRepository;
    }

    public override async Task<ActionResponse<IEnumerable<Empresa>>> GetAsync(PaginationDTO pagination) =>
        await _empresasRepository.GetAsync(pagination);

    public async Task<IEnumerable<Empresa>> GetComboAsync() => 
        await _empresasRepository.GetComboAsync();

    public override async Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination) => 
        await _empresasRepository.GetTotalRecordsAsync(pagination);
}
