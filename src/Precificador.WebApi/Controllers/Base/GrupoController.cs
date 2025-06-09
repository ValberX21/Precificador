using Microsoft.AspNetCore.Mvc;

using Precificador.Application.Model;
using Precificador.Application.Services;

namespace Precificador.WebApi.Controllers.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public class GrupoController : BaseModelController<Grupo, IGrupoService>
    {
        public GrupoController(IGrupoService service, ILogger<GrupoController> logger) : base(service, logger)
        {
        }
    }
}