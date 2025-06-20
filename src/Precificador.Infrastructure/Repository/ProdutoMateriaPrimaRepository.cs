using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Precificador.Domain.Entities;
using Precificador.Domain.Filters;
using Precificador.Domain.Repository;
using Precificador.Infrastructure.Data;
using Precificador.Infrastructure.Repository.Base;
using System.Data.Common;

namespace Precificador.Infrastructure.Repository
{
    public class ProdutoMateriaPrimaRepository(AppDbContext context, ILogger<ProdutoMateriaPrima> logger) : CrudRepositoryBase<ProdutoMateriaPrima, ProdutoMateriaPrimaFilter>(context, logger), IProdutoMateriaPrimaRepository
    {
        public override async Task<IEnumerable<ProdutoMateriaPrima>?> GetByFilterAsync(ProdutoMateriaPrimaFilter filter)
        {
            try
            {
                var query = Context.ProdutoMateriaPrimas.AsQueryable().Where(c => c.Ativo);

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

                return await query.ToListAsync().ConfigureAwait(false);
            }
            catch (DbException dbEx)
            {
                LogErrorFetchingByFilter(Logger, typeof(ProdutoMateriaPrima).Name, dbEx);
                return [];
            }
            catch (InvalidOperationException invalidOpEx)
            {
                LogErrorFetchingByFilter(Logger, typeof(ProdutoMateriaPrima).Name, invalidOpEx);
                return [];
            }
            catch (Exception ex)
            {   
                LogErrorFetchingByFilter(Logger, typeof(ProdutoMateriaPrima).Name, ex);
                throw;
            }
        }
    }
}