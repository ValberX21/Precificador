using Microsoft.Extensions.Logging;
using Precificador.Domain.Entities;
using Precificador.Domain.Filters;
using Precificador.Domain.Repository;
using Precificador.Infrastructure.Data;
using Precificador.Infrastructure.Repository.Base;

namespace Precificador.Infrastructure.Repository
{
    public class ColecaoRepository(AppDbContext context, ILogger<Colecao> logger) : CrudRepositoryBase<Colecao, NomeFilter>(context, logger), IColecaoRepository
    {
    }
}