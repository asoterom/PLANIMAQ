using Planimaq.Shared.DTOs;
using Planimaq.Shared.Entities;
using Planimaq.Shared.Responses;

namespace Planimaq.backend.UnitsOfWork.Interfaces
{
    public interface IEmpresasUnitOfWork
    {
        Task<IEnumerable<Empresa>> GetComboAsync();
        Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination);
        Task<ActionResponse<IEnumerable<Empresa>>> GetAsync(PaginationDTO pagination);

        

        
    }
}
