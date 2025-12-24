using Planimaq.backend.Repositories.Interfaces;
using Planimaq.backend.UnitsOfWork.Interfaces;
using Planimaq.Shared.DTOs;
using Planimaq.Shared.Entities;
using Planimaq.Shared.Responses;

namespace Planimaq.backend.UnitsOfWork.Implementations
{
    public class CategoriesUnitOfWork : GenericUnitOfWork<Category>, ICategoriesUnitOfWork
    {
        private readonly ICategoriesRepository _categoriesRepository;

        public CategoriesUnitOfWork(IGenericRepository<Category> repository,
            ICategoriesRepository categoriesRepository) : base(repository)
        {
            _categoriesRepository = categoriesRepository;
        }

        public override async Task<ActionResponse<IEnumerable<Category>>> GetAsync(PaginationDTO pagination) =>
        await _categoriesRepository.GetAsync(pagination);

        public override async Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination) =>
            await  _categoriesRepository.GetTotalRecordsAsync(pagination); 
    }
}
