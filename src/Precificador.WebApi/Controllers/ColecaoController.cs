using Microsoft.AspNetCore.Mvc;

using Precificador.Application.Services;
using Precificador.Domain.Filters;
using Precificador.Domain.Repository;
using Precificador.WebApi.Controllers.Base;

namespace Precificador.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColecaoController(IColecaoService service, ILogger logger) : BaseCrudController<Application.Model.Colecao, Domain.Entities.Colecao, NomeFilter, IColecaoService, IColecaoRepository>(service, logger)
    {

    }
}