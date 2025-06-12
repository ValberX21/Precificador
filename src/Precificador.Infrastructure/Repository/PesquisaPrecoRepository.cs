using Microsoft.Extensions.Logging;
using Precificador.Domain.Entities;
using Precificador.Domain.Filters;
using Precificador.Domain.Repository;
using Precificador.Infrastructure.Data;
using Precificador.Infrastructure.Repository.Base;

namespace Precificador.Infrastructure.Repository
{
    public class PesquisaPrecoRepository(AppDbContext context, ILogger<PesquisaPreco> logger) : CrudRepositoryBase<PesquisaPreco, PesquisaPrecoFilter>(context, logger), IPesquisaPrecoRepository
    {
    }
}