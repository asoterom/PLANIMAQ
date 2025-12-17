using Planimaq.Shared.Entities;
using Planimaq.Shared.Responses;

namespace Planimaq.backend.Repositories.Interfaces
{
    public interface IStatesRepository
    {
        Task<ActionResponse<State>> GetAsync(int id);
        Task<ActionResponse<IEnumerable<State>>> GetAsync();
    }
}
