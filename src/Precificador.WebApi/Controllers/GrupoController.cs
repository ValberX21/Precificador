using Microsoft.AspNetCore.Mvc;

using Precificador.Application.Model;
using Precificador.Application.Services;
using Precificador.WebApi.Controllers.Base;

namespace Precificador.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GrupoController(IGrupoService service, ILogger<GrupoController> logger) : BaseModelController<Grupo, IGrupoService>(service, logger)
    {
        //
    }
}