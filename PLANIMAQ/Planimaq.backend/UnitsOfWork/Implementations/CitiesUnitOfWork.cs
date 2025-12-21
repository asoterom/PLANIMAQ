using Planimaq.backend.Repositories.Interfaces;
using Planimaq.backend.UnitsOfWork.Interfaces;
using Planimaq.Shared.DTOs;
using Planimaq.Shared.Entities;
using Planimaq.Shared.Responses;

namespace Planimaq.backend.UnitsOfWork.Implementations
{
    public class CitiesUnitOfWork : GenericUnitOfWork<City>, ICitiesUnitOfWork
    {
        private readonly ICitiesRepository _citiesRepository;

        public CitiesUnitOfWork(IGenericRepository<City> repository, ICitiesRepository citiesRepository) : base(repository)
        {
            _citiesRepository = citiesRepository;
        }

        public override async Task<ActionResponse<IEnumerable<City>>> GetAsync(PaginationDTO pagination) => 
            await _citiesRepository.GetAsync(pagination);

        public override async Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination) => 
            await _citiesRepository.GetTotalRecordsAsync(pagination);

    }

}
