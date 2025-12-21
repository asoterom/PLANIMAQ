using Microsoft.AspNetCore.Mvc;
using Planimaq.backend.UnitsOfWork.Interfaces;
using Planimaq.Shared.Entities;

namespace Planimaq.backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificacionesController : GenericController<Notificacion>
    {
        public NotificacionesController(IGenericUnitOfWork<Notificacion> unitOfWork) : base(unitOfWork)
        {
        }
    }
}
