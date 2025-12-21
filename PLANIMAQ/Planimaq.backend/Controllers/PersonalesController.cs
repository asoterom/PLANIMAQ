using Microsoft.AspNetCore.Mvc;
using Planimaq.backend.UnitsOfWork.Interfaces;
using Planimaq.Shared.Entities;

namespace Planimaq.backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonalesController : GenericController<Personal>
    {
        public PersonalesController(IGenericUnitOfWork<Personal> unitOfWork) : base(unitOfWork)
        {
        }
    }
}
