using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Precificador.Domain.Entities;
using Precificador.Domain.Filters;
using Precificador.Domain.Repository;
using Precificador.Infrastructure.Data;
using Precificador.Infrastructure.Repository.Base;

namespace Precificador.Infrastructure.Repository
{
    public class ColecaoRepository(AppDbContext context, ILogger<Colecao> logger) : CrudRepositoryBase<Colecao, ColecaoFilter>(context, logger), IColecaoRepository
    {
        public override async Task<IEnumerable<Colecao>> GetByFilterAsync(ColecaoFilter filter)
        {
            try
            {
                var query = _context.Colecoes.AsQueryable().Where(c => c.Ativo);

                if (filter != null)
                {
                    if (!string.IsNullOrEmpty(filter.Nome))
                    {
                        query = query.Where(c => c.Nome.Contains(filter.Nome));
                    }

                    if (filter.Ano.HasValue)
                    {
                        query = query.Where(c => c.Ano == filter.Ano.Value);
                    }
                }

                return await query.ToListAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao buscar todos os registros de {EntityType}", typeof(Colecao).Name);
                return [];
            }
        }
    }
}