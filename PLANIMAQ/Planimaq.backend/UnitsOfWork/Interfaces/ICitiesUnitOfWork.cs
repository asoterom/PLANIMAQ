using Planimaq.Shared.DTOs;
using Planimaq.Shared.Entities;
using Planimaq.Shared.Responses;

namespace Planimaq.backend.UnitsOfWork.Interfaces
{
    public interface ICitiesUnitOfWork
    {
        Task<ActionResponse<IEnumerable<City>>> GetAsync(PaginationDTO pagination);

        Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination);

    }
}
