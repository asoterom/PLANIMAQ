using Planimaq.Shared.DTOs;
using Planimaq.Shared.Entities;
using Planimaq.Shared.Responses;

namespace Planimaq.backend.UnitsOfWork.Interfaces
{
    public interface ICategoriesUnitOfWork
    {
        Task<ActionResponse<IEnumerable<Category>>> GetAsync(PaginationDTO pagination);

        Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination);

    }
}
