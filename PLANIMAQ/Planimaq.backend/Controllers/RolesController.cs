using Microsoft.AspNetCore.Mvc;
using Planimaq.backend.UnitsOfWork.Interfaces;
using Planimaq.Shared.Entities;

namespace Planimaq.backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolesController : GenericController<Rol>
    {
        public RolesController(IGenericUnitOfWork<Rol> unitOfWork) : base(unitOfWork)
        {
        }
    }
}
