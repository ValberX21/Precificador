using Microsoft.Extensions.Logging;
using Precificador.Domain.Entities;
using Precificador.Domain.Filters;
using Precificador.Domain.Repository;
using Precificador.Infrastructure.Data;
using Precificador.Infrastructure.Repository.Base;

namespace Precificador.Infrastructure.Repository
{
    public class ProdutoRepository(AppDbContext context, ILogger<Produto> logger) : CrudRepositoryBase<Produto, NomeFilter>(context, logger), IProdutoRepository
    {
    }
}