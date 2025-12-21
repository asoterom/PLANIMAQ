using Microsoft.AspNetCore.Mvc;
using Planimaq.backend.UnitsOfWork.Interfaces;
using Planimaq.Shared.Entities;

namespace Planimaq.backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : GenericController<Usuario>
    {
        public UsuariosController(IGenericUnitOfWork<Usuario> unitOfWork) : base(unitOfWork)
        {
        }
    }
}
