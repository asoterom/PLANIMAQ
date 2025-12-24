using Planimaq.Shared.DTOs;
using Planimaq.Shared.Entities;
using Planimaq.Shared.Responses;

namespace Planimaq.backend.UnitsOfWork.Interfaces
{
    public interface ICountriesUnitOfWork
    {
        Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination);
        Task<ActionResponse<Country>> GetAsync(int id);
        Task<ActionResponse<IEnumerable<Country>>> GetAsync();
        Task<ActionResponse<IEnumerable<Country>>> GetAsync(PaginationDTO pagination);
    }
}
