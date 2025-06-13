using Microsoft.AspNetCore.Mvc;

using Precificador.Application.Services;
using Precificador.Domain.Filters;
using Precificador.Domain.Repository;
using Precificador.WebApi.Controllers.Base;

namespace Precificador.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GrupoController(IGrupoService service, ILogger logger) : BaseCrudController<Application.Model.Grupo, Domain.Entities.Grupo, NomeFilter, IGrupoService, IGrupoRepository>(service, logger)
    {

    }
}