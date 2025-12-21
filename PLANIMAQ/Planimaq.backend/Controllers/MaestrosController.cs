using Microsoft.AspNetCore.Mvc;
using Planimaq.backend.UnitsOfWork.Interfaces;
using Planimaq.Shared.Entities;

namespace Planimaq.backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MaestrosController : GenericController<Maestro>
    {
        public MaestrosController(IGenericUnitOfWork<Maestro> unitOfWork) : base(unitOfWork)
        {
        }
    }
}
