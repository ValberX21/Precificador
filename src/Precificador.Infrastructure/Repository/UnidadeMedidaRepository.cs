using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Precificador.Domain.Entities;
using Precificador.Domain.Filters;
using Precificador.Domain.Repository;
using Precificador.Infrastructure.Data;
using Precificador.Infrastructure.Repository.Base;

namespace Precificador.Infrastructure.Repository
{
    public class UnidadeMedidaRepository(AppDbContext context, ILogger<UnidadeMedida> logger) : CrudRepositoryBase<UnidadeMedida, NomeFilter>(context, logger), IUnidadeMedidaRepository
    {
        public override async Task<IEnumerable<UnidadeMedida>> GetByFilterAsync(NomeFilter filter)
        {
            try
            {
                var query = _context.UnidadesMedida.AsQueryable().Where(c => c.Ativo);

                if (filter != null && !string.IsNullOrEmpty(filter.Nome))
                {
                    query = query.Where(c => c.Nome.Contains(filter.Nome));
                }

                return await query.ToListAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                _logErrorFetchingByFilter(_logger, typeof(UnidadeMedida).Name, ex);
                return [];
            }
        }
    }
}