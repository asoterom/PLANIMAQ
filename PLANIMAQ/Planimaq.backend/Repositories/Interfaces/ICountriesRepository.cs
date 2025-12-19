using Planimaq.Shared.DTOs;
using Planimaq.Shared.Entities;
using Planimaq.Shared.Responses;

namespace Planimaq.backend.Repositories.Interfaces
{
    public interface ICountriesRepository
    {
        Task<ActionResponse<IEnumerable<Country>>> GetAsync(PaginationDTO pagination);
        Task<ActionResponse<Country>> GetAsync(int id);
        Task<ActionResponse<IEnumerable<Country>>> GetAsync();
    }
}
