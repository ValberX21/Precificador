using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Precificador.Domain.Entities;
using Precificador.Domain.Filters;
using Precificador.Domain.Repository;
using Precificador.Infrastructure.Data;
using Precificador.Infrastructure.Repository.Base;

namespace Precificador.Infrastructure.Repository
{
    public class ProdutoMateriaPrimaRepository(AppDbContext context, ILogger<ProdutoMateriaPrima> logger) : CrudRepositoryBase<ProdutoMateriaPrima, ProdutoMateriaPrimaFilter>(context, logger), IProdutoMateriaPrimaRepository
    {
        public override async Task<IEnumerable<ProdutoMateriaPrima>> GetByFilterAsync(ProdutoMateriaPrimaFilter filter)
        {
            try
            {
                var query = _context.ProdutoMateriaPrimas.AsQueryable().Where(c => c.Ativo);

                if (filter != null)
                {
                    if (filter.ProdutoId.HasValue)
                    {
                        query = query.Where(c => c.ProdutoId == filter.ProdutoId.Value);
                    }

                    if (!string.IsNullOrEmpty(filter.ProdutoNome))
                    {
                        query = query.Where(c => c.Produto != null && c.Produto.Nome.Contains(filter.ProdutoNome));
                    }

                    if (filter.MateriaPrimaId.HasValue)
                    {
                        query = query.Where(c => c.MateriaPrimaId == filter.MateriaPrimaId.Value);
                    }

                    if (!string.IsNullOrEmpty(filter.MateriaPrimaNome))
                    {
                        query = query.Where(c => c.MateriaPrima != null && c.MateriaPrima.Nome.Contains(filter.MateriaPrimaNome));
                    }
                }

                return await query.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao buscar todos os registros de {EntityType}", typeof(ProdutoMateriaPrima).Name);
                return [];
            }
        }
    }
}