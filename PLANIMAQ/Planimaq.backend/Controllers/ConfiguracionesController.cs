using Microsoft.AspNetCore.Mvc;
using Planimaq.backend.UnitsOfWork.Interfaces;
using Planimaq.Shared.Entities;

namespace Planimaq.backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConfiguracionesController : GenericController<Configuracion>
    {
        public ConfiguracionesController(IGenericUnitOfWork<Configuracion> unitOfWork) : base(unitOfWork)
        {
        }
    }
}
