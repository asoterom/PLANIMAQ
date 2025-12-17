using Microsoft.EntityFrameworkCore;
using Planimaq.backend.Data;
using Planimaq.backend.Repositories.Interfaces;
using Planimaq.Shared.Entities;
using Planimaq.Shared.Responses;

namespace Planimaq.backend.Repositories.Implementations
{
    public class CountriesRepository : GenericRepository<Country>, ICountriesRepository
    {
        private readonly DataContext _context;

        public CountriesRepository(DataContext context) : base(context)
        {
            _context = context;
        }
        public async override Task<ActionResponse<IEnumerable<Country>>> GetAsync()
        {
            var countries = await _context.Countries
                .Include(x=>x.States)
                .ToListAsync();
            return new ActionResponse<IEnumerable<Country>>()
            {
                WasSuccess = true,
                Result = countries
            };
        }

        public async override Task<ActionResponse<Country>> GetAsync(int id)
        {
            var country = await _context.Countries
                .Include(x => x.States!)
                .ThenInclude(x => x.Cities)
                .FirstOrDefaultAsync(x => x.id == id);

            if (country == null)
            {
                return new ActionResponse<Country>
                {
                    Message = "Registro no encontrado"
                };
            }

            return new ActionResponse<Country>()
            {
                WasSuccess = true,
                Result = country
            };
        }
    }
}
