using Microsoft.EntityFrameworkCore;
using Planimaq.backend.Data;
using Planimaq.backend.Helpers;
using Planimaq.backend.Repositories.Interfaces;
using Planimaq.Shared.DTOs;
using Planimaq.Shared.Entities;
using Planimaq.Shared.Responses;

namespace Planimaq.backend.Repositories.Implementations
{
    public class EmpresasRepository : GenericRepository<Empresa>, IEmpresasRepository
    {
        private readonly DataContext _context;

        public EmpresasRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<ActionResponse<IEnumerable<Empresa>>> GetAsync(PaginationDTO pagination)
        {
            var querytable = _context.Empresas.AsQueryable();
            if (!string.IsNullOrWhiteSpace(pagination.Filter))
            {
                querytable = querytable.Where(x => x.Name.ToLower().Contains(pagination.Filter.ToLower()));
            }
            return new ActionResponse<IEnumerable<Empresa>>
            {
                WasSuccess = true,
                Result = await querytable
                    .OrderBy(x => x.Name)
                    .Paginate(pagination)
                    .ToListAsync()
            };
        }

        public async Task<IEnumerable<Empresa>> GetComboAsync()
        {
            return await _context.Empresas
                .OrderBy(c  => c.Name)
                .ToListAsync();
        }

        public override async Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination)
        {
            var querytable = _context.Empresas.AsQueryable();
            if (!string.IsNullOrWhiteSpace(pagination.Filter))
            {
                querytable = querytable.Where(x => x.Name.ToLower().Contains(pagination.Filter.ToLower()));
            }

            double count = await querytable .CountAsync();

            return new ActionResponse<int>
            {
                WasSuccess = true,
                Result = (int) count
            };

        }
    }
}
