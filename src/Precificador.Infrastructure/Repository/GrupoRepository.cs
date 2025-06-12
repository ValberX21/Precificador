using Microsoft.Extensions.Logging;
using Precificador.Domain.Entities;
using Precificador.Domain.Filters;
using Precificador.Domain.Repository;
using Precificador.Infrastructure.Data;
using Precificador.Infrastructure.Repository.Base;

namespace Precificador.Infrastructure.Repository
{
    public class GrupoRepository(AppDbContext context, ILogger<Grupo> logger) : CrudRepositoryBase<Grupo, NomeFilter>(context, logger), IGrupoRepository
    {
    }
}