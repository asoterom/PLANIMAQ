using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Planimaq.backend.Data;
using Planimaq.backend.UnitsOfWork.Interfaces;
using Planimaq.Shared.DTOs;
using Planimaq.Shared.Entities;
using System.Threading.Tasks;

namespace Planimaq.backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //public class CountriesController:ControllerBase
    public class CountriesController : GenericController<Country>
    {
        private readonly ICountriesUnitOfWork _countriesUnitOfWork;

        public CountriesController(IGenericUnitOfWork<Country> unitOfWork,
            ICountriesUnitOfWork countriesUnitOfWork) : base(unitOfWork)
        {
            _countriesUnitOfWork = countriesUnitOfWork;
        }

        [HttpGet("paginated")]
        public override async Task<IActionResult> GetAsync(PaginationDTO pagination)
        {
            var response = await _countriesUnitOfWork.GetAsync(pagination);
            if (response.WasSuccess)
            {
                return Ok(response.Result);
            }
            return BadRequest();
        }


        [HttpGet]
        public override async Task<IActionResult> GetAsync()
        {
            var action = await _countriesUnitOfWork.GetAsync();
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return BadRequest(action.Message);
        }

        [HttpGet("{id}")]
        public override async Task<IActionResult> GetAsync(int id)
        {
            var action = await _countriesUnitOfWork.GetAsync(id);
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return NotFound();
        }

        //private readonly DataContext _context;

        //public CountriesController(DataContext context)
        //{
        //    _context = context;
        //}
        //[HttpGet]
        //public async Task<IActionResult> GetAsync()
        //{

        //    //var result = await _context.Countries.ToListAsync();
        //    //return Ok(result);
        //    return Ok(await _context.Countries.ToListAsync());

        //}


        //[HttpPost]
        //public async Task<IActionResult> PostAsync(Country country) { 
        //    _context.Countries.Add(country);
        //    await _context.SaveChangesAsync();
        //    return Ok(country);

        //}
    }
}
