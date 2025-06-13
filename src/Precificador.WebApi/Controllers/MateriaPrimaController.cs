using Microsoft.AspNetCore.Mvc;

using Precificador.Application.Services;
using Precificador.Domain.Filters;
using Precificador.Domain.Repository;
using Precificador.WebApi.Controllers.Base;

namespace Precificador.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MateriaPrimaController(IMateriaPrimaService service, ILogger logger) : BaseCrudController<Application.Model.MateriaPrima, Domain.Entities.MateriaPrima, NomeFilter, IMateriaPrimaService, IMateriaPrimaRepository>(service, logger)
    {

    }
}