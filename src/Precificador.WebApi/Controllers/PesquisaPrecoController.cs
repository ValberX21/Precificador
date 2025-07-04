﻿using Microsoft.AspNetCore.Mvc;

using Precificador.Application.Services;
using Precificador.Domain.Filters;
using Precificador.Domain.Repository;
using Precificador.WebApi.Controllers.Base;

namespace Precificador.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PesquisaPrecoController(IPesquisaPrecoService service, ILogger<PesquisaPrecoController> logger) : BaseCrudController<Application.Model.PesquisaPreco, Domain.Entities.PesquisaPreco, PesquisaPrecoFilter, IPesquisaPrecoService, IPesquisaPrecoRepository>(service, logger)
    {

    }
}