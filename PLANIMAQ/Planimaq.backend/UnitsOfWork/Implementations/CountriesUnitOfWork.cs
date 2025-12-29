using Planimaq.backend.Repositories.Interfaces;
using Planimaq.backend.UnitsOfWork.Interfaces;
using Planimaq.Shared.DTOs;
using Planimaq.Shared.Entities;
using Planimaq.Shared.Responses;

namespace Planimaq.backend.UnitsOfWork.Implementations
{
    public class CountriesUnitOfWork : GenericUnitOfWork<Country>, ICountriesUnitOfWork
    {
        //private readonly IGenericRepository<Country> _repository;
        private readonly ICountriesRepository _countriesRepository;

        public CountriesUnitOfWork(IGenericRepository<Country> repository,
            ICountriesRepository countriesRepository ) : base(repository)
        {
            _countriesRepository = countriesRepository;
            //_repository = repository;
        }

        public override async Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination) => 
            await _countriesRepository.GetTotalRecordsAsync(pagination);

        public override async Task<ActionResponse<IEnumerable<Country>>> GetAsync(PaginationDTO pagination) => 
            await _countriesRepository.GetAsync(pagination);
        public override async Task<ActionResponse<IEnumerable<Country>>> GetAsync() => 
            await _countriesRepository.GetAsync();

        public override async Task<ActionResponse<Country>> GetAsync(int id) =>
          await _countriesRepository.GetAsync(id);

        public async Task<IEnumerable<Country>> GetComboAsync() => 
            await _countriesRepository.GetComboAsync();
    }
}
