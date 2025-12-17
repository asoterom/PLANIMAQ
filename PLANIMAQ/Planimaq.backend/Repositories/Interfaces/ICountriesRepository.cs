using Planimaq.Shared.Entities;
using Planimaq.Shared.Responses;

namespace Planimaq.backend.Repositories.Interfaces
{
    public interface ICountriesRepository
    {
        Task<ActionResponse<Country>> GetAsync(int id);
        Task<ActionResponse<IEnumerable<Country>>> GetAsync();
    }
}
